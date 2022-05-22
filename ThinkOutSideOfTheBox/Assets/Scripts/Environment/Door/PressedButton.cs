using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressedButton : MonoBehaviour
{
    [SerializeField] private AudioClip[] onReleasedClips;
    [SerializeField] private AudioClip[] onPressedClips;
    private AudioSource audioSource;
    public UnityEvent onPressed, onReleased;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;
    private bool isPressd;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }
    private void PlayReleasedClip()
    {
        int rand = Random.Range(0, onReleasedClips.Length);
        Debug.Log(rand);
        audioSource.clip = onReleasedClips[rand];
        audioSource.Play();
    }
    private void PlayPressedClip()
    {
        int rand = Random.Range(0, onPressedClips.Length);
        audioSource.clip = onPressedClips[rand];
        audioSource.Play();
    }

    private void Update()
    {
        if(!isPressd && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if(isPressd && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if(Mathf.Abs(value) < deadzone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressd = true;
        PlayPressedClip();
        onPressed.Invoke();
    }

    private void Released()
    {
        isPressd = false;
        PlayReleasedClip();
        onReleased.Invoke();
        
    }
}
