using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Input for Keybinds")]
    [SerializeField] private KeyCode Pickup = KeyCode.E;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;
    public static KeyCode pauseKey = KeyCode.Escape;

    public KeyCode GetJump()
    {
        return jumpKey;
    }

    public KeyCode GetPickup()
    {
        return Pickup;
    }
    public KeyCode GetSprint()
    {
        return sprintKey;
    }

    public KeyCode GetCrouch()
    {
        return crouchKey;
    }

    public static KeyCode GetPauseKey()
    {
        return pauseKey;
    }
}
