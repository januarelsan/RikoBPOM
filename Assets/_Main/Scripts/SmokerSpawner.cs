using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject smoker;
    [SerializeField] private Transform playerPos;

    private float playerOffset = 30;
    // Start is called before the first frame update
    void Start()
    {
          Invoke("SpawnEnemy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy(){
        //   CancelInvoke() // Stop the timer (I don't think you need it, try without)
        Vector3 spawnPos = new Vector3 (playerPos.position.x + playerOffset, smoker.transform.position.y, smoker.transform.position.z);
        Instantiate(smoker, spawnPos, smoker.transform.rotation, transform);
        // Start a new timer for the next random spawn
        Invoke("SpawnEnemy", Random.Range (5, 10));
    }
}
