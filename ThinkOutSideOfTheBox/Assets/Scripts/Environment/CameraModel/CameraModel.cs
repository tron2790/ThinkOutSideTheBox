using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour
{
    [SerializeField] private Light redLight;
    private Transform Pos;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform cameraHead;
    [SerializeField] private GameObject vCam;
    [SerializeField] private GameObject vCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Pos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        redLight.intensity = Mathf.PingPong(Time.time * 2, 6);

        Vector3 PlayerPos = new Vector3(-player.transform.position.x, player.transform.position.y, -player.transform.position.z);

        cameraHead.LookAt(player.transform);
    }

    public void EnableCamera()
    {
        vCam.SetActive(true);
        vCanvas.SetActive(true);
    }

    public void DisableCamera()
    {
        vCam.SetActive(false);
        vCanvas.SetActive(false);
    }

    public void playQoute()
    {
        GetComponent<DeathQoutes>().PlayQoute();
    }





}
