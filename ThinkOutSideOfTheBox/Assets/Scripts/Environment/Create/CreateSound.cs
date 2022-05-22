using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sfx;
    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayClip()
    {
        int rand = Random.Range(0, sfx.Length);
        audioSource.clip = sfx[rand];
        audioSource.Play();
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        
            PlayClip();
        
        
    }
}
