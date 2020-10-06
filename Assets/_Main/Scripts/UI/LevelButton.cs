using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Sprite[] containerSprites;
    [SerializeField] private Sprite yellowStarSprite;
    
    private int episode;
    private int level;


    void Start(){
        GetComponent<Button>().onClick.AddListener(ToLevel);
        episode = transform.parent.parent.GetSiblingIndex();
        level = transform.GetSiblingIndex() + (episode * 5);

        if(SelectEpisodeManager.Instance.GetLevelHistoryDataAt(level) != null){

            if(SelectEpisodeManager.Instance.GetLevelHistoryDataAt(level).opened){
                GetComponent<Button>().interactable = true;
                GetComponent<Image>().sprite = containerSprites[1];

                //Star
                for(int i = 0; i < 3; i++){
                    transform.GetChild(1).GetChild(i).GetComponent<Image>().enabled = true;
                    if(i < SelectEpisodeManager.Instance.GetLevelHistoryDataAt(level).stars)
                        transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = yellowStarSprite;
                }
                

                //open padlock
                transform.GetChild(2).gameObject.SetActive(false);
            }

        }
        
    }

    void ToLevel(){
        GameData.Instance.SelectedEpisode = episode;
        GameData.Instance.SelectedLevel = level;
    }
}
