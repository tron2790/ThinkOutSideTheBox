using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private GameObject doorModel;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;
    [SerializeField] private int numOfButtonsToPress = 1;
    [SerializeField] private int counter;
    private Animator animator;
    private bool isDoorClosedTriggered;





    public void setIsDoorClosed(bool _closed)
    {
        isDoorClosedTriggered = _closed;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    public void DoorClose()
    {
        
        animator.SetBool("isOpen", false);
        audioSource.PlayOneShot(closeClip);
        if (isDoorClosedTriggered)
        {
            return;
        }
        counter--;
    }

    public void DoorOpen()
    {
        if (isDoorClosedTriggered)
        {
            return;
        }
        counter++;
        if (numOfButtonsToPress == counter)
        {
            audioSource.PlayOneShot(openClip);
            animator.SetBool("isOpen", true);
        }
        
    }
}
