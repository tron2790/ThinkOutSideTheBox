using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody[] rbs;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            if(collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1f)
            {
                collider.enabled = false;
                for (int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].isKinematic = false;
                }
            }
        }
    }
}
