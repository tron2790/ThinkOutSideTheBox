using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLift : MonoBehaviour
{

    [SerializeField] private Door ExitDoor;
    // Start is called before the first frame update
    [SerializeField] private ViewerSquare viewerSquare;

    [SerializeField] private AudioClip LiftLoop;
    [SerializeField] private AudioClip LiftArival;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }


    public void playLoop()
    {
        audioSource.loop = true;
        audioSource.PlayOneShot(LiftLoop);
    }


    public void LiftAnimationFinsihed()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(LiftArival);
        if (viewerSquare != null)
        {
            viewerSquare.SetStarted(true);
        }
        ExitDoor.DoorOpen();
    }
}
