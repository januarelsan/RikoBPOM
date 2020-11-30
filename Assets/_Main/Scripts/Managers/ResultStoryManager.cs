using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultStoryManager : Singleton<ResultStoryManager>
{
    [SerializeField] private AudioClip[] resultClips;
    [SerializeField] private TypeWriter writer;
    [SerializeField] private StoryData[] happyStoryDatas;
    [SerializeField] private StoryData[] sadStoryDatas;

    [SerializeField] private Image image;
    [SerializeField] private GameObject nextButtonObj;
    private StoryData currentStoryData;
    private int dataIndex;
    private int storyIndex;

    private int resultType;

    // Start is called before the first frame update
    void Start()
    {
        
        // Debug.Log("Selected Level: " + GameData.Instance.SelectedLevel);
        CheckStory();
    }
    
    void CheckStory(){
        // GameData.Instance.ResultStoryType = 0;
        // GameData.Instance.ResultStoryIndex = 10;
        if(GameData.Instance.ResultStoryType == 1){                    
            currentStoryData = happyStoryDatas[(GameData.Instance.ResultStoryIndex / 5 ) - 1];            
            GetComponent<AudioSource>().PlayOneShot(resultClips[1]);
        } else if(GameData.Instance.ResultStoryType == 0)
        {
            currentStoryData = sadStoryDatas[(GameData.Instance.ResultStoryIndex / 5 ) - 1];            
            GetComponent<AudioSource>().PlayOneShot(resultClips[0]);
        }
        resultType = GameData.Instance.ResultStoryType;
        image.enabled = true;
        nextButtonObj.SetActive(true);
        WritingIntro();

        
    }

    void WritingIntro(){
        if(storyIndex < currentStoryData.sprites.Length )
            image.sprite = currentStoryData.sprites[storyIndex];

        writer.StartWriting(currentStoryData.captions[storyIndex]);
    }

    public void Next(){
        
        if(!writer.GetIsWriting()){
            storyIndex++;
            if(storyIndex < currentStoryData.captions.Length){
                WritingIntro();
            } else {
                if(resultType == 1){
                    SceneController.Instance.GoToScene("Badge");
                }else{
                    SceneController.Instance.GoToScene("SelectLevel");
                }
            }
        }else
        {        
            writer.FinishWriting();
        }


    }

    

}
