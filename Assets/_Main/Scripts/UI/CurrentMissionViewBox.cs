using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CurrentMissionViewBox : MonoBehaviour
{

    [SerializeField] private Sprite[] missionBarSprites;

    [SerializeField] private Image[] enemyMissionBarImages;
    [SerializeField] private Image[] friendMissionBarImages;
    [SerializeField] private Image[] coinMissionBarImages;
    [SerializeField] private Text episodeText;    
    [SerializeField] private Text enemyText;
    [SerializeField] private Text friendText;
    [SerializeField] private Text coinText;

    private MissionData[] missionDatas;
    [SerializeField] private MissionData currentMission;
    private MissionData selectedMission;


    void Start(){

        missionDatas = MissionManager.Instance.GetMissionDatas();
        selectedMission = missionDatas[GameData.Instance.SelectedLevel];

        episodeText.text =  "Episode " + (selectedMission.episode+1) + "/5";
                        
        enemyText.text = "Hancurkan " + selectedMission.enemyM + " musuh disekitar";
        friendText.text = "Selamatkan " + selectedMission.friendM + " teman dari rokok";
        coinText.text = "Kumpulkan " + selectedMission.coinM + " coin";

        SetupResult();
    }

    public void SetupResult(){
        float enemyPercent = 100;
        float friendPercent = 100;
        float coinPercent = 100;
        if(selectedMission.enemyM > 0)
            enemyPercent = (int) Math.Round((double)(100 * currentMission.enemyM) / selectedMission.enemyM);
        
        if(selectedMission.friendM > 0)
            friendPercent = (int) Math.Round((double)(100 * currentMission.friendM) / selectedMission.friendM);
            
        if(selectedMission.coinM > 0)
            coinPercent = (int) Math.Round((double)(100 * currentMission.coinM) / selectedMission.coinM);

        // Debug.Log("Enemy Percent: " + enemyPercent);
        // Debug.Log("Friend Percent: " + friendPercent);
        // Debug.Log("Coin Percent: " + coinPercent);

        for (int i = 0; i < (int)Math.Round(enemyPercent/20); i++)
        {
            enemyMissionBarImages[i].sprite = missionBarSprites[1];
        }

        for (int i = 0; i < (int)Math.Round(friendPercent/20); i++)
        {
            friendMissionBarImages[i].sprite = missionBarSprites[1];
        }

        for (int i = 0; i < (int)Math.Round(coinPercent/20); i++)
        {
            coinMissionBarImages[i].sprite = missionBarSprites[1];
        }
    }
}

