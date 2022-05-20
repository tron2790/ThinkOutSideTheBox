using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AI))]
public class AI_45_Degree : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMast;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    private AI AiController;
    private void Awake()
    {
        AiController = GetComponent<AI>();
    }

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMast);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distnaceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distnaceToTarget, obstructionMask))
                    canSeePlayer = true;

                else canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void Update()
    {
        if (canSeePlayer)
        {
            AiController.ShootAtPlayer();
            transform.LookAt(playerRef.transform.position);
        }
    }
}
