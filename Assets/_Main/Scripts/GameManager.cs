using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject gameOverPanel;
    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
        ItemSpawner.Instance.StopSpawn();
    }
}
