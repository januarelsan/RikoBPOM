using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionViewPresenter : MonoBehaviour
{
    [SerializeField] private bool previewInGame;
    [SerializeField] private MissionManager missionManager;
    [SerializeField] private Text episodeText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text enemyText;
    [SerializeField] private Text friendText;
    [SerializeField] private Text coinText;

    [SerializeField] private MissionData[] missionDatas;

    void Start(){
        // int x = Random.Range(0, missionDatas.Length);
        int x = GameData.Instance.SelectedLevel;

        episodeText.text =  "Episode " + (missionDatas[x].episode+1) + "/5";
        descriptionText.text = missionDatas[x].description;

        if(!previewInGame){
            
            enemyText.text = "Hancurkan " + missionDatas[x].enemyM + " musuh disekitar";
            friendText.text = "Selamatkan " + missionDatas[x].friendM + " teman dari rokok";
            coinText.text = "Kumpulkan " + missionDatas[x].coinM + " uang";
        }

    }

    void Update() {

        int x = GameData.Instance.SelectedLevel;

        if(previewInGame){

            enemyText.text = missionManager.GetEnemyPoint() + "/" + missionDatas[x].enemyM + " Musuh.";
            friendText.text = missionManager.GetFriendPoint() +  "/" + missionDatas[x].friendM + " Teman";
            coinText.text = missionManager.GetCoinPoint() +  "/" + missionDatas[x].coinM + " Uang";

        }    
    }
}
