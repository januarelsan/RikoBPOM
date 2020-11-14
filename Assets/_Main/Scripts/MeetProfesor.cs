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

    [SerializeField] private AudioClip[] clips;

    private int questIndex;
    private int[] randomIndex;

    private GameObject professorObject;
    
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

        for (int i = 0; i < choiceObjects.Length; i++)        
        {
            choiceObjects[i].SetActive(false);
        }


        for (int i = 0; i < questionDatas[randomIndex[questIndex]].options.Length; i++)        
        {
            choiceObjects[i].transform.GetChild(0).GetComponent<Text>().text = questionDatas[randomIndex[questIndex]].options[i];            
            choiceObjects[i].SetActive(true);            
            questText.gameObject.SetActive(true);
        }

        questIndex++;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Profesor")   {
            GetComponent<PlayerState>().SwitchState("Idle");     
            professorObject = col.gameObject;
            SetQuest();
            convePanel.SetActive(true);
        }
        
    }

    public void Answering(int choiceIndex){
        convePanel.SetActive(false);

        if(choiceIndex == questionDatas[randomIndex[questIndex]].answerIndex){
            coinData.value += 10;
            MissionManager.Instance.AddCoinPoint(10);
            SpawnGimmickEffect.Instance.SpawnGimmick(2);
            GetComponent<AudioSource>().PlayOneShot(clips[1]);
        } else {
            GetComponent<AudioSource>().PlayOneShot(clips[0]);
        }

        professorObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(AfterAnswer());
        
    }

    IEnumerator AfterAnswer(){

        
        yield return new WaitForSeconds(0);
        GetComponent<PlayerState>().SwitchState("Run");
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
