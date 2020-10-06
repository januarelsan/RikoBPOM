using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaManager : MonoBehaviour
{
    #pragma warning disable 0649
    private int questIndex;
    private int[] randomIndex;
    private int score;

    [SerializeField] private QuestionData[] questionDatas;
    [SerializeField] private CoinData coinData;

    // UI

    [SerializeField] private GameObject finishPanel;

    [SerializeField] private Text indexText;
    [SerializeField] private Text questText;

    [SerializeField] private GameObject answerResultObject;
    [SerializeField] private Sprite[] answerResultSprites;

    [SerializeField] private Sprite[] choiceResultSprites;

    [SerializeField] private GameObject[] choiceObjects;

    [SerializeField] private AudioClip[] answerResultClips;

    [SerializeField] private Text poinText;


    // Start is called before the first frame update
    void Start()
    {
        randomIndex = new int[questionDatas.Length];
        for (int i = 0; i < questionDatas.Length; i++)
		{			
			randomIndex[i] = i;
		}

        RandomIntArrayElement(randomIndex,20);

        SetQuest();
    }


	void RandomIntArrayElement(int[] array, int randomAmount){
                
		for (int i = 0; i < randomAmount; i++)
		{			
			int elementX = UnityEngine.Random.Range(0, array.Length);
			int elementY = UnityEngine.Random.Range(0, array.Length);
			var temp = array[elementX];
			array[elementX] = array[elementY];
			array[elementY] = temp;
		}
	}

    void SetQuest(){
        //Set Quest Index Text
        indexText.text = "Soal " + (questIndex+1) + "/5";

        //Set Quest Text
        questText.text = questionDatas[randomIndex[questIndex]].quest;

        for (int i = 0; i < 4; i++)        
        {
            choiceObjects[i].SetActive(false);
        }


        for (int i = 0; i < questionDatas[randomIndex[questIndex]].options.Length; i++)        
        {
            choiceObjects[i].transform.GetChild(0).GetComponent<Text>().text = questionDatas[randomIndex[questIndex]].options[i];
            choiceObjects[i].SetActive(false);
            choiceObjects[i].SetActive(true);
            questText.gameObject.SetActive(false);
            questText.gameObject.SetActive(true);
        }
    }

    public void Answering(int choiceIndex){
        if(choiceIndex == questionDatas[randomIndex[questIndex]].answerIndex){
            AnswerIsTrue(choiceIndex);
        } else {
            AnswerIsFalse(choiceIndex);
        }    

        for (int i = 0; i < 4; i++)        
        {
            choiceObjects[i].GetComponent<Button>().interactable = false;
        }    
    }

    public void TakeAward(){
        coinData.value += score;
        SceneController.Instance.GoToScene("SelectLevel");
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
        poinText.text = score + " Poin";
    }

    void AnswerIsTrue(int choiceIndex){
        Debug.Log("Answer Is True");
        answerResultObject.GetComponent<Image>().sprite = answerResultSprites[1];
        answerResultObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(answerResultClips[1]);
        choiceObjects[choiceIndex].GetComponent<Image>().sprite = choiceResultSprites[1];
        score+=10;
        
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
