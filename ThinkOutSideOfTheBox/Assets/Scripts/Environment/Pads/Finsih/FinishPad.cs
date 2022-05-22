using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPad : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Active");
        }
    }


    public void LoadNextLevel()
    {
        LevelManager.Instance.LoadScene(nextLevel);
    }
}
