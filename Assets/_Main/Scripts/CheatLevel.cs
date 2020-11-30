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
        

        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpened(i,1);
        }

        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpenedEnemy(i,1);
        }

        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpenedFriend(i,1);
        }

        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpenedCoin(i,1);
        }

        
        SceneController.Instance.RestartScene();
    }

    public void CloseAllLevel(){
        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpened(i,0);
        }

        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpenedEnemy(i,0);
        }

        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpenedFriend(i,0);
        }

        for (int i = 0; i < 25; i++)
        {
            GameData.Instance.SetLevelOpenedCoin(i,0);
        }

        SceneController.Instance.RestartScene();
    }
}
