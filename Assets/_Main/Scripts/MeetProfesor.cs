using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetProfesor : MonoBehaviour
{
    [SerializeField] private QuestionData[] questionDatas;
    [SerializeField] private CoinData coinData;


    [SerializeField] private GameObject convePanel;
    [SerializeField] private Text questText;
    [SerializeField] private GameObject[] choiceObjects;

    private int questIndex;
    private int[] randomIndex;
    
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetQuest(){
        

        //Set Quest Text
        questText.text = questionDatas[randomIndex[questIndex]].quest;

        for (int i = 0; i < 4; i++)        
        {
            choiceObjects[i].SetActive(false);
        }


        for (int i = 0; i < questionDatas[randomIndex[questIndex]].options.Length; i++)        
        {
            choiceObjects[i].transform.GetChild(0).GetComponent<Text>().text = questionDatas[randomIndex[questIndex]].options[i];            
            choiceObjects[i].SetActive(true);            
            questText.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Profesor")   {
            GetComponent<PlayerState>().SwitchState("Idle");
            GetComponent<Animator>().SetTrigger("Idle");
            convePanel.SetActive(true);
        }
        
    }

    public void Answering(int choiceIndex){
        convePanel.SetActive(false);

        if(choiceIndex == questionDatas[randomIndex[questIndex]].answerIndex){
            coinData.value += 10;
        }


        GetComponent<PlayerState>().SwitchState("Default");
        GetComponent<Animator>().SetTrigger("Run");
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
}
