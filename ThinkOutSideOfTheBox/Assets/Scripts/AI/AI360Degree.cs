using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AI))]
public class AI360Degree : MonoBehaviour
{
    [Header("Radius")]
    [SerializeField] private float detectRadius = 10f;
    [SerializeField] private float hearyouRadius = 20f;
    private AI AIController;


    private Transform target;



    private void Awake()
    {
        AIController = GetComponent<AI>();
    }



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 dir = new Vector3(0f, 0f, target.position.x);
        if (distance <= detectRadius)
        {

            transform.LookAt(target);
            AIController.ShootAtPlayer();

        }
        if (distance <= hearyouRadius)
        {
            transform.LookAt(target);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, hearyouRadius);
    }
}
