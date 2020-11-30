using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    [SerializeField] private MissionData[] missionDatas;

    [SerializeField] private GameObject[] smokers;
    [SerializeField] private GameObject mafia;
    [SerializeField] private GameObject spg;
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject[] dashItems;
    [SerializeField] private GameObject professor;

    [SerializeField] private Transform playerPos;

    private float playerOffset = 30;
    private MissionData selectedMission;
    private int episodeM;
    private int levelM;
    private int friendM;
    private List<int> spawnedList = new List<int>();

    private int spawnIndex;

    private bool isSpawning;


    // Start is called before the first frame update
    void Start()
    {
        selectedMission = MissionManager.Instance.GetSelectedMission();       
        
        // Debug.Log("Enemy Mission: " + selectedMission.enemy);
        // Debug.Log("Friend Mission: " + selectedMission.friend);
        // Debug.Log("Coin Mission: " + selectedMission.coin);

        

        SetupSpawnList();
        SwapListItem();

        
        
        Invoke("Spawning", 5);
    }

    
    
    

    

    void Spawning(){
        isSpawning = true;
        GameObject objToSpawn = null;
        switch (spawnedList[spawnIndex])
        {
            case 0:                                
                objToSpawn = smokers[Random.Range(0,smokers.Length)];
                break;
            case 1:
                objToSpawn = mafia;
                break;
            case 2:
                objToSpawn = obstacles[Random.Range(0,obstacles.Length)];
                break;
            case 3:
                objToSpawn = dashItems[Random.Range(0,dashItems.Length)];
                break;
            case 4:
                objToSpawn = buildings[Random.Range(0,buildings.Length)];
                break;
            case 5:
                objToSpawn = items[Random.Range(0,items.Length)];
                break;
            case 6:
                objToSpawn = spg;
                break;
            case 7:
                objToSpawn = professor;
                break;
            default:
                objToSpawn = smokers[Random.Range(0,smokers.Length)];
                break;
        }
        
        Vector3 spawnPos = new Vector3(0,0,0);
        spawnPos = new Vector3 (playerPos.position.x + playerOffset, objToSpawn.transform.position.y, objToSpawn.transform.position.z);
        Instantiate(objToSpawn, spawnPos, objToSpawn.transform.rotation, transform);
        spawnIndex++;
        

        if(spawnIndex >= spawnedList.Count){
            spawnIndex = 0;
        }
        // Start a new timer for the next random spawn
        Invoke("Spawning", Random.Range (5, 7));
        // Invoke("Spawning", Random.Range (1, 2));
    }

    void SetupSpawnList(){
        for (int i = 0; i < selectedMission.smokers; i++)
        {
            spawnedList.Add(0);
        }

        for (int i = 0; i < selectedMission.mafia; i++)
        {
            spawnedList.Add(1);
        }

        for (int i = 0; i < selectedMission.obstacles; i++)
        {
            spawnedList.Add(2);
        }

        for (int i = 0; i < selectedMission.dashItems; i++)
        {
            spawnedList.Add(3);
        }

        for (int i = 0; i < selectedMission.buildings; i++)
        {
            spawnedList.Add(4);
        }

        for (int i = 0; i < selectedMission.items; i++)
        {
            spawnedList.Add(5);
        }

        for (int i = 0; i < selectedMission.spg; i++)
        {
            spawnedList.Add(6);
        }

        for (int i = 0; i < selectedMission.professors; i++)
        {
            spawnedList.Add(7);
        }
        

    }

    void SwapListItem(){

        // string list = "";
        // for (int i = 0; i < spawnedList.Count; i++)
        // {
        //     list += spawnedList[i] + ", ";
        // }
        // Debug.Log("Before: " + list);

        for (int i = 0; i < Random.Range(10,25); i++)
        {
            int x = Random.Range(0, spawnedList.Count);
            int y = Random.Range(0, spawnedList.Count);

            int temp = spawnedList[x];
            spawnedList[x] = spawnedList[y];
            spawnedList[y] = temp;
            
        }

        // list = "";
        // for (int i = 0; i < spawnedList.Count; i++)
        // {
        //     list += spawnedList[i] + ", ";
        // }
        // Debug.Log("After: " + list);
    }

    public void StopSpawn(){
        CancelInvoke();
        isSpawning = false;
    }

    public void StartSpawn(float startDelay = 3){
        Invoke("Spawning", startDelay);
    }
}
