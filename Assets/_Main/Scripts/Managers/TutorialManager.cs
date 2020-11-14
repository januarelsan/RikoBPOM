using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private Image tutorImage;
    [SerializeField] private Sprite[] tutorSprites;

    [SerializeField] private GameObject exitPanel;

    int index;

    public void Next(){
        Debug.Log("Next");
        if(index < tutorSprites.Length - 1){
            index++;
            tutorImage.sprite = tutorSprites[index];
        } else
        {            
            if(exitPanel)
            {
                exitPanel.SetActive(true);
                GameData.Instance.ShowTutorial = 1;
            }
        }

        
        
    }

    public void Prev(){
        Debug.Log("Prev");
        if(index > 0){
            index--;
            tutorImage.sprite = tutorSprites[index];
        }
    }
}
