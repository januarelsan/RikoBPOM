using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private TypeWriter writer;
    [SerializeField] private StoryData[] introStoryDatas;
    [SerializeField] private Image image;
    [SerializeField] private GameObject nextButtonObj;
    private int dataIndex;
    private int storyIndex;

    // Start is called before the first frame update
    void Start()
    {
        
        // Debug.Log("Selected Level: " + GameData.Instance.SelectedLevel);
        CheckStory();
    }
    
    void CheckStory(){
        if(GameData.Instance.StoryType == 1){
            dataIndex = GameData.Instance.SelectedEpisode;
            image.enabled = true;
            nextButtonObj.SetActive(true);
            WritingIntro();

        } else if(GameData.Instance.StoryType == 0)
        {
            ToMissionScene();
        }

        
    }

    void WritingIntro(){
        if(storyIndex < introStoryDatas[dataIndex].sprites.Length )
            image.sprite = introStoryDatas[dataIndex].sprites[storyIndex];

        writer.StartWriting(introStoryDatas[dataIndex].captions[storyIndex]);
    }

    public void Next(){
        
        if(!writer.GetIsWriting()){
            storyIndex++;
            if(storyIndex < introStoryDatas[dataIndex].captions.Length){
                WritingIntro();
            } else 
                ToMissionScene();
        }else
        {        
            writer.FinishWriting();
        }


    }

    void ToMissionScene(){
        SceneController.Instance.GoToScene("Mission");
    }

    

}
