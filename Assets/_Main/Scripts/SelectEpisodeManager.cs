using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEpisodeManager : Singleton<SelectEpisodeManager>
{
    [SerializeField] private GameObject[] episodes;
    [SerializeField] private LevelHistoryData[] levelHistories;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LevelHistoryData GetLevelHistoryDataAt(int index){
        if(index < levelHistories.Length)
            return levelHistories[index];
        else
            return null;
    }

    public void Next(){
        
        if(index < 2){
            index++;
            ChangeEpisode();
        }

    }

    public void Prev(){
        
        if(index > 0){
            index--;
            ChangeEpisode();
        }

    }

    private void ChangeEpisode(){
        foreach (GameObject episode in episodes)
        {
            episode.SetActive(false);
        }
        switch (index)
        {
            case 0:
                episodes[0].SetActive(true);
                episodes[1].SetActive(true);
                break;
            case 1:
                episodes[2].SetActive(true);
                episodes[3].SetActive(true);
                break;
            case 2:
                episodes[4].SetActive(true);                
                break;
            default:
                episodes[0].SetActive(true);
                episodes[1].SetActive(true);
                break;
        }
    }
}
