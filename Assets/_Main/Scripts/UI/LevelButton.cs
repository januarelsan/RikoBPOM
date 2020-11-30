using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Sprite[] containerSprites;
    [SerializeField] private Sprite yellowStarSprite;
    [SerializeField] private Sprite brownStarSprite;
    
    private int episode;
    private int level;

    void Awake(){
        
    }
    void Start(){
        // GetComponent<Button>().onClick.AddListener(ToLevel);
        episode = transform.parent.parent.GetSiblingIndex();
        level = transform.GetSiblingIndex() + (episode * 5);       

        

        if(GameData.Instance.GetLevelOpened(level) == 1){
            GetComponent<Button>().interactable = true;
            GetComponent<Image>().sprite = containerSprites[1];
                        
            //open padlock
            transform.GetChild(2).gameObject.SetActive(false);

            //enable brown star
            for (int i = 0; i < 3; i++)
            {
                transform.GetChild(1).GetChild(i).GetComponent<Image>().enabled = true;  
                transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = brownStarSprite;
            }


            //3 star if level completed
            if(GameData.Instance.GetLevelOpened(level + 1) == 1){
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(1).GetChild(i).GetComponent<Image>().enabled = true;  
                    transform.GetChild(1).GetChild(i).GetComponent<Image>().sprite = yellowStarSprite;
                }
            }


            //Star by mission
            // if(GameData.Instance.GetLevelOpenedEnemy(level) == 1){
            //     transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;                
            //     transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = yellowStarSprite;
            // }

            // if(GameData.Instance.GetLevelOpenedFriend(level) == 1){

            //     transform.GetChild(1).GetChild(1).GetComponent<Image>().enabled = true;                
            //     transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = yellowStarSprite;
            // }

            // if(GameData.Instance.GetLevelOpenedCoin(level) == 1){
            //     transform.GetChild(1).GetChild(2).GetComponent<Image>().enabled = true;                
            //     transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = yellowStarSprite;
            // }
        }                
                
    }

    public void ToLevel(){
        GameData.Instance.SelectedEpisode = episode;
        GameData.Instance.SelectedLevel = level;

        if(level - episode * 5 == 0){
            GameData.Instance.StoryType = 1;
        } else {
            GameData.Instance.StoryType = 0;
        }

        if(GameData.Instance.ShowTutorial == 0){
            SceneController.Instance.GoToScene("Tutorial");    
        }else{
            SceneController.Instance.GoToScene("Poster");
        }
    }
}
