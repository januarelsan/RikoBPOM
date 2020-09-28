using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour
{
    private int questIndex;

    
    // UI

    [SerializeField] private GameObject finishPanel;

    [SerializeField] private Text indexText;
    [SerializeField] private Text questText;

    [SerializeField] private GameObject answerResultObject;
    [SerializeField] private Sprite[] answerResultSprites;

    [SerializeField] private Sprite[] choiceResultSprites;

    [SerializeField] private GameObject[] choiceObjects;

    [SerializeField] private AudioClip[] answerResultClips;

    // Start is called before the first frame update
    void Start()
    {
        SetQuest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetQuest(){
        //Set Quest Index Text
        indexText.text = "Soal " + (questIndex+1) + "/5";

        //Set Quest Text
        questText.text = TriviaData.Instance.GetQuestString(questIndex);


        for (int i = 0; i < 4; i++)        
        {
            choiceObjects[i].transform.GetChild(0).GetComponent<Text>().text = TriviaData.Instance.GetChoiceString(questIndex, i);
            choiceObjects[i].SetActive(false);
            choiceObjects[i].SetActive(true);
            questText.gameObject.SetActive(false);
            questText.gameObject.SetActive(true);
        }
    }

    public void Answering(int choiceIndex){
        if(choiceIndex == TriviaData.Instance.GetTrueAnswer(questIndex)){
            AnswerIsTrue(choiceIndex);
        } else {
            AnswerIsFalse(choiceIndex);
        }    

        for (int i = 0; i < 4; i++)        
        {
            choiceObjects[i].GetComponent<Button>().interactable = false;
        }    
    }

    public void NextQuestion(){

        //Reset Choices
        for (int i = 0; i < 4; i++)        
        {
            choiceObjects[i].GetComponent<Image>().sprite = choiceResultSprites[2];
            choiceObjects[i].GetComponent<Button>().interactable = true;
        }

        if(questIndex < 4){
            questIndex++;
            SetQuest();
        } else {
            FinishGame();
        }
    }

    void FinishGame(){
        Debug.Log("Finish Game");    
        finishPanel.SetActive(true);
    }

    void AnswerIsTrue(int choiceIndex){
        Debug.Log("Answer Is True");
        answerResultObject.GetComponent<Image>().sprite = answerResultSprites[1];
        answerResultObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(answerResultClips[1]);
        choiceObjects[choiceIndex].GetComponent<Image>().sprite = choiceResultSprites[1];
        
    }

    void AnswerIsFalse(int choiceIndex){
        Debug.Log("Answer Is False");
        answerResultObject.GetComponent<Image>().sprite = answerResultSprites[0];
        answerResultObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(answerResultClips[0]);
        choiceObjects[choiceIndex].GetComponent<Image>().sprite = choiceResultSprites[0];
        choiceObjects[TriviaData.Instance.GetTrueAnswer(questIndex)].GetComponent<Image>().sprite = choiceResultSprites[1];
    }
}
