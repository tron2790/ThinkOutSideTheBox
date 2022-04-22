using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour
{
    [SerializeField] private Light redLight;
    private Transform Pos;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform cameraHead;
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



}
