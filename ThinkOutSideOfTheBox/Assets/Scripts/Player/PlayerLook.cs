using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [Header("References")]
    [SerializeField] wallRun wallRun;

    [Header("Sensitivity")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform cam;
    [SerializeField] private Transform orientation;
    private float mouseX;
    private float mouseY;

    private float mutiplier = 0.01f;

    private float xRotation;
    private float yRotation;

    private void Awake()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void LateUpdate()
    {
        MyInput();

        cam.localRotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
       
    }


    private void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        
        yRotation += mouseX * sensX * mutiplier; // we do this becuase we rotate on the Y Axis when we look horizontally
        xRotation -= mouseY * sensY * mutiplier; // we do this becuase we rotate on the X Acis when we look Vertically

        xRotation = Mathf.Clamp(xRotation, -90, 90f); // limit the X Axis so we dont look behinde the player

    }
}
