using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "LevelHistoryData", menuName = "ScriptableObjects/Level History Data")]
public class LevelHistoryData : ScriptableObject
{
    public int episode;
    public int level;
    public int stars;

    public bool enemyMission;
    public bool friendMission;
    public bool coinMission;
    // public int enemy;
    // public int friend;
    // public int coin;
    public bool opened;
    
    public int GetStar(){
        stars = 0;
        if(enemyMission)
            stars++;
        if(friendMission)
            stars++;
        if(coinMission)
            stars++;

        return stars;
    }   
}
