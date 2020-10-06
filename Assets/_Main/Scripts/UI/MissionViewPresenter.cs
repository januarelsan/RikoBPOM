using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionViewPresenter : MonoBehaviour
{
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
        enemyText.text = "Hancurkan " + missionDatas[x].enemy + " musuh disekitar";
        friendText.text = "Selamatkan " + missionDatas[x].friend + " teman dari rokok";
        coinText.text = "Kumpulkan " + missionDatas[x].coin + " coin";
    }
}
