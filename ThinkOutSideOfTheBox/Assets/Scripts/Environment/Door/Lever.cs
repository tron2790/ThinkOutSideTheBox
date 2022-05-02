using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    public bool leverState { get; private set; }



    public void Off()
    {
        onReleased.Invoke();
        leverState = false;
    }

    public void On()
    {
        onPressed.Invoke();
        leverState = true;
    }




}
