using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathQoutes : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip[] Lines;
    private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void PlayQoute()
    {
        int i = Random.Range(0, Lines.Length);

        audioSource.PlayOneShot(Lines[i]);
    }

}
