using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMissionManager : MonoBehaviour
{

    [SerializeField] private MissionData[] missionDatas;
    [SerializeField] private Transform[] itemList;
    [SerializeField] private Text selectedMissionEpisodeText;
    [SerializeField] private Text selectedMissionLevelText;
    [SerializeField] private InputField enemyField;
    [SerializeField] private InputField friendField;
    [SerializeField] private InputField coinField;
    private int missionIndex;

    public void SelectMission(int index){
        missionIndex = index;
        enemyField.text = missionDatas[missionIndex].enemyM.ToString();
        friendField.text = missionDatas[missionIndex].friendM.ToString();
        coinField.text = missionDatas[missionIndex].coinM.ToString();

        selectedMissionEpisodeText.text = "Episode " + (missionDatas[missionIndex].episode + 1);
        selectedMissionLevelText.text = "Level " + ( missionDatas[missionIndex].level - (5 * missionDatas[missionIndex].episode) + 1) ;
        // selectedMissionLevelText.text = "Level " + missionDatas[missionIndex].level ;
    }

    public void SaveData(){
        missionDatas[missionIndex].enemyM = int.Parse(enemyField.text);
        missionDatas[missionIndex].friendM = int.Parse(friendField.text);
        missionDatas[missionIndex].coinM = int.Parse(coinField.text);
    }

    public void SetPreview(){
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i].GetChild(0).GetComponent<Text>().text = i+1 + "";
            itemList[i].GetChild(1).GetComponent<Text>().text = missionDatas[i].enemyM + "";
            itemList[i].GetChild(2).GetComponent<Text>().text = missionDatas[i].friendM + "";
            itemList[i].GetChild(3).GetComponent<Text>().text = missionDatas[i].coinM + "";
        }
    }

    
}
