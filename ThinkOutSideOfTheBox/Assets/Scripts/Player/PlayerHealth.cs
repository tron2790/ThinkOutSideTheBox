using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float respawnTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void instantKill()
    {
        Die();
    }


    public void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(awaitDeath(respawnTimer));
    }

    private IEnumerator awaitDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CheckPoint cp = FindObjectOfType<Stage>().getCurrentStageCheckpoint();
        transform.position = cp.GetCheckPoint().transform.position;
        GetComponent<PlayerMovement>().enabled = true;
    }
}
