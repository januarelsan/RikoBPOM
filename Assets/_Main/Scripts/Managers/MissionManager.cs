﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : Singleton<MissionManager>
{
    [SerializeField] private MissionData currentMission;
    [SerializeField] private MissionData[] missionDatas;

    [SerializeField] private LevelHistoryData[] levelHistories;

    [SerializeField] private CoinData generalCoinData;

    private bool enemyMissionCompleted;
    private bool friendMissionCompleted;
    private bool coinMissionCompleted;
    private MissionData selectedMission;

    void Awake(){
        // Reset Data
        currentMission.enemyM = 0;
        currentMission.friendM = 0;
        currentMission.coinM = 0;

        selectedMission = missionDatas[GameData.Instance.SelectedLevel];
        Debug.Log("Selected Episode: " + selectedMission.episode);
        Debug.Log("Selected Level: " + selectedMission.level);
        
        BackgroundManager.Instance.SetBackground();

    }

    void Update(){
        CheckProgress();        
    }

    void CheckProgress(){
        if(currentMission.enemyM >= selectedMission.enemyM){
            enemyMissionCompleted = true;
            GameData.Instance.LevelOpenedEnemy = 1;
            currentMission.enemyM = selectedMission.enemyM;
        } else {
            GameData.Instance.LevelOpenedEnemy = 0;
            enemyMissionCompleted = false;
        }

        if(currentMission.friendM >= selectedMission.friendM){
            friendMissionCompleted = true;
            GameData.Instance.LevelOpenedFriend = 1;    
            currentMission.friendM = selectedMission.friendM;
        } else {
            GameData.Instance.LevelOpenedFriend = 0;    
            friendMissionCompleted = false;
        }

        if(currentMission.coinM >= selectedMission.coinM){
            GameData.Instance.LevelOpenedCoin = 1;
            coinMissionCompleted = true;
            currentMission.coinM = selectedMission.coinM;
        } else {
            GameData.Instance.LevelOpenedCoin = 0;
            coinMissionCompleted = false;
        }
        
        if(enemyMissionCompleted == true && friendMissionCompleted == true && coinMissionCompleted == true){                                
            GameManager.Instance.WinGame();
        }
    }

    public MissionData[] GetMissionDatas(){
        return missionDatas;
    }

    public MissionData GetSelectedMission(){
        return selectedMission;
    }

    

    public void AddEnemyPoint(int value){
        currentMission.enemyM += value;
    }

    public void AddFriendPoint(int value){
        currentMission.friendM += value;
    }

    public void AddCoinPoint(int value){
        currentMission.coinM += value;
        generalCoinData.AddCoin(value);
    }

    public void SubCoinPoint(int value){
        currentMission.coinM -= value;
        generalCoinData.AddCoin(-value);
        if(currentMission.coinM <= 0){
            currentMission.coinM = 0;
        }
    }

    public int GetEnemyPoint(){
        return currentMission.enemyM;
    }

    public int GetFriendPoint(){
        return currentMission.friendM;
    }

    public int GetCoinPoint(){
        return currentMission.coinM;
    }

    
}
