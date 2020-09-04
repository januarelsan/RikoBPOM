using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform playerPos;

    private float playerOffset = 50;
    // Start is called before the first frame update
    void Start()
    {
          Invoke("SpawnItem", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem(){
        //   CancelInvoke() // Stop the timer (I don't think you need it, try without)
        int item = Random.Range(0, items.Length);
        Vector3 spawnPos = new Vector3 (playerPos.position.x + playerOffset, items[item].transform.position.y, items[item].transform.position.z);
        Instantiate(items[item], spawnPos, items[item].transform.rotation, transform);
        // Start a new timer for the next random spawn
        Invoke("SpawnItem", Random.Range (5, 15));
    }
}
