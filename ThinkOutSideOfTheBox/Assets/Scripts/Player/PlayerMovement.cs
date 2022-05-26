using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float movementMultiplier = 10f;
    [SerializeField] private float AirMultiplier = 0.4f;
    [SerializeField] private float maxSpeed = 20f;
    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundlayer;
   
    [Header("Drag")]
    [SerializeField] private float groundDrag = 6;
    [SerializeField] private float airDrag = 2f;

    [Header("Sprinting")]
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 6f;
    [SerializeField] private float acceleration = 10f;

    [Header("Player Height")]
    [SerializeField] private float playerHeight = 2f;


    [Header("Transforms")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform groundCheck;

    

    [Header("Audio")]
    [SerializeField] private AudioClip[] footStepSounds;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private AudioClip jumpSound;

    [Header("Audio Settings")]
    [SerializeField] private float stepInterval;
    [SerializeField] [Range(0f, 1f)] private float runstepLenghten;

    [Header("Sliding")]
    public float slideForce = 400;

    private PlayerInput playerInput;

    [SerializeField] private Text velocityText;
    //Private variables
    private RaycastHit slopehit;
    private Rigidbody rb;
    private float horizontalMovement;
    private float verticalMovement;
    private float stepCycle;
    private float nextStep;
    private bool isGrounded;
    private bool isWalking;
    private bool previouslyGrounded;
    private Vector3 moveDirection;
    private Vector3 slopeMoveDirection;
    private AudioSource audioSource;
    [SerializeField] private wallRun wallRun;
    private bool isCrouching;
    private bool doubleJump;
    private bool onSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopehit, playerHeight / 2 + 0.5f))
        {
            if(slopehit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        audioSource = GetComponent<AudioSource>();

      //  DataPresistanceManager.Instance.LevelLoaded();
       // DataPresistanceManager.Instance.LoadGame();
    }

    private void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void Update()
    {
        if (PauseMenu.isPuased)
        {
            return;
        }


        velocityText.text = rb.velocity.magnitude.ToString();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundlayer);

        MyInput();
        ControlDrag();
        ControlSpeed();

        if (Input.GetKeyDown(playerInput.GetJump()) && isGrounded)
        {
            Jump();
            PlayJumpSound();
        }
        if(Input.GetKeyDown(playerInput.GetJump()) && doubleJump && !isGrounded && !wallRun.isWallRunning)
        {
            doubleJump = false;
            Jump();
            PlayJumpSound();
        }
        if (wallRun.isWallRunning)
        {
            doubleJump = true;
        }
        if(!previouslyGrounded && isGrounded)
        {
            doubleJump = true;
            PlayLandingSound();
        }
        if (Input.GetKeyDown(playerInput.GetCrouch()))
            StartCrouch();
        if (Input.GetKeyUp(playerInput.GetCrouch()))
            StopCrouch();


        if (isCrouching &&  isGrounded)
        {
            isCrouching = false;
            // rb.AddForce(moveSpeed * Time.deltaTime * -rb.velocity.normalized * slideCounterMovement);
           // rb.AddForce(orientation.transform.forward * slideForce, ForceMode.VelocityChange);
        }

        


        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopehit.normal);

        previouslyGrounded = isGrounded;
    }


    private void StartCrouch() {

        isCrouching = true;
         transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
        // transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            if (rb.velocity.magnitude > 6)
            {
                if (isGrounded)
                {
                    Debug.Log("Slide");
                    rb.AddForce(orientation.transform.forward * slideForce,ForceMode.VelocityChange);
                }

            }
        
        

    }

    private void StopCrouch()
    {
        isCrouching = false;
       // transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
    }

    private void PlayLandingSound()
    {
        if (onSlope()) { return; }
        if (isCrouching) return;
        audioSource.clip = landSound;
        audioSource.Play();
        nextStep = stepCycle + .5f;
    }

    private void PlayJumpSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    private void ProgressStepCycle(float speed)
    {
        if(rb.velocity.sqrMagnitude > 0 && (moveDirection.x != 0|| moveDirection.y != 0))
        {
            stepCycle += (rb.velocity.magnitude + (speed * (isWalking ? 1f : runstepLenghten))) * Time.fixedDeltaTime;
        }

        if(!(stepCycle > nextStep))
        {
            return;
        }

        nextStep = stepCycle + stepInterval;
        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        if (!isGrounded && !wallRun.isWallRunning)
        {
            return;
        }
        
        int n = Random.Range(1, footStepSounds.Length);
        audioSource.clip = footStepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);

        footStepSounds[n] = footStepSounds[0];
        footStepSounds[0] = audioSource.clip;

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode.Impulse);
    }

    private void ControlSpeed()
    {
        //if(isSliding) { return; }
        if(Input.GetKey(playerInput.GetSprint()) && isGrounded)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
            isWalking = false;
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
            isWalking = true;
        }
       
    }

    private void MyInput()
    {
       // if (!isWalking && isCrouching) return;
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
       
        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }


    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * Time.deltaTime * 10);

        if(isCrouching && isGrounded)
        {
            rb.AddForce(Vector3.down * Time.deltaTime * 3000);
        }
        if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > maxSpeed)
        {
            float fallspeed = rb.velocity.y;
            Vector3 n = rb.velocity.normalized * maxSpeed;
            rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }


        MovePlayer();
        
        ProgressStepCycle(moveSpeed);
    }

    private void MovePlayer()
    {

       


       // if(isSliding) { return; }
        if (isGrounded && !onSlope())
        {
            Debug.Log("grounded");
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        } else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * AirMultiplier, ForceMode.Acceleration);
        } else if(isGrounded && onSlope()){
            rb.AddForce(orientation.transform.forward * 100 * movementMultiplier * AirMultiplier, ForceMode.Acceleration);
            Debug.Log("Slope");
        }
    }
}
