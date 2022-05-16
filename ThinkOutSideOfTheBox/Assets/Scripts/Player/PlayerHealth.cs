using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour, IDataPersistance
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float respawnTimer = 2f;
    [SerializeField] private float regenerateHealthTimer = 1f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject camHolder;
    private bool isDead;
    [SerializeField] private float CurrentHealth;
    private bool isReganHealth;
    private bool isAttacked;
    [SerializeField] private float AttackedCoolDown = 5f;
    private float AttackedTimer;
    // Start is called before the first frame update
    void Start()
    {



        //CurrentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(30);
        }

        healthBar.value = CurrentHealth;

        if(CurrentHealth <= 0)
        {
            Die();
        }
        if (!isAttacked)
        {
            if (CurrentHealth != health && !isReganHealth)
            {

                StartCoroutine(RegainHealthOverTime());
            }
        }

        if (isAttacked)
        {
            AttackedTimer -= Time.deltaTime;
            if (AttackedTimer <= 0f)
            {
                isAttacked = false;
            }
        }
    }

    public void TakeDamage(float _value)
    {
        CurrentHealth -= _value;
        isAttacked = true;
        AttackedTimer = AttackedCoolDown;
    }


    private IEnumerator RegainHealthOverTime()
    {
        isReganHealth = true;
        while(CurrentHealth < health)
        {
            CurrentHealth++;
            yield return new WaitForSeconds(regenerateHealthTimer);
        }
        isReganHealth = false;
    }


    public void Die()
    {
        if(isDead) { return; }
        CameraModel cm = FindObjectOfType<Stage>().getCurrentStageCameraModel();
        cm.EnableCamera();
        cm.playQoute();
        camHolder.SetActive(false);
        
        GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(awaitDeath(respawnTimer));
        isDead = true;
    }

    

    private IEnumerator awaitDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Respawn();
    }


    private void Respawn()
    {
        //temp code 
        CheckPoint cp = FindObjectOfType<Stage>().getCurrentStageCheckpoint();
        transform.position = cp.GetCheckPoint().transform.position;
        GetComponent<PlayerMovement>().enabled = true;
        CurrentHealth = health;
        camHolder.SetActive(true);
        CameraModel cm = FindObjectOfType<Stage>().getCurrentStageCameraModel();
        cm.DisableCamera();
        isDead = false;
    }

    public void LoadData(GameData data)
    {
        this.CurrentHealth = data.health;
    }

    public void SaveData(ref GameData data)
    {
        data.health = this.CurrentHealth;
    }
}
