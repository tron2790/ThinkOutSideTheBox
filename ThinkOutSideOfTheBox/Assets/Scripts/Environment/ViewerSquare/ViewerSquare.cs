using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerSquare : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip[] Lines;
    private AudioSource audioSource;
    int CurrentLinesIndex;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        //audioSource.clip = Lines[0];
        //audioSource.Play();
       // CurrentLinesIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && CurrentLinesIndex != Lines.Length)
        {
            
                audioSource.clip = Lines[CurrentLinesIndex];
                audioSource.Play();
            
           
            CurrentLinesIndex++;
        }
    }
}
