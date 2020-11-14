using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatLevel : MonoBehaviour
{
    public LevelHistoryData[] levelHistoryData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenAllLevel(){
        GameData.Instance.LevelOpened = 24;
        GameData.Instance.LevelOpenedEnemy = 1;
        GameData.Instance.LevelOpenedFriend = 1;
        GameData.Instance.LevelOpenedCoin = 1;
        SceneController.Instance.RestartScene();
    }

    public void CloseAllLevel(){
        GameData.Instance.LevelOpened = 0;
        GameData.Instance.LevelOpenedEnemy = 0;
        GameData.Instance.LevelOpenedFriend = 0;
        GameData.Instance.LevelOpenedCoin = 0;

        SceneController.Instance.RestartScene();
    }
}
