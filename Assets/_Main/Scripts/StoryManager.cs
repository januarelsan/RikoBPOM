using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private TypeWriter writer;
    [SerializeField] private StoryData[] storyDatas;
    [SerializeField] private Image image;
    private int dataIndex;
    private int storyIndex;

    // Start is called before the first frame update
    void Start()
    {
        Writing();
    }

    void Writing(){
        image.sprite = storyDatas[dataIndex].sprites[storyIndex];
        writer.StartWriting(storyDatas[dataIndex].captions[storyIndex]);
    }

    public void Next(){
        
        if(!writer.GetIsWriting()){
            storyIndex++;
            if(storyIndex < storyDatas[dataIndex].sprites.Length){
                Writing();
            } else 
                ToGameScene();
        }

        writer.FinishWriting();

    }

    void ToGameScene(){
        SceneController.Instance.GoToScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
