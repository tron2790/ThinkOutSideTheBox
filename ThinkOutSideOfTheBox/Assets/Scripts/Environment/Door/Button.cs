using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] private Door door;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;
    private bool isPressd;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
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
        door.DoorOpen();
    }

    private void Released()
    {
        isPressd = false;
        door.DoorClose();
    }
}
