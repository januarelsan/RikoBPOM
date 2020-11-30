using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetProfesor : MonoBehaviour
{
    [SerializeField] private PauseController pauseController;
    [SerializeField] private SpawnerManager spawnerManager;
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
        // randomIndex = new int[questionDatas.Length];
        // for (int i = 0; i < questionDatas.Length; i++)
		// {			
		// 	randomIndex[i] = i;
		// }

        // RandomIntArrayElement(randomIndex,20);

        

    }

    // Update is called once per frame
    void Update()
    {
        if(professorObject){
            if(professorObject.GetComponent<BoxCollider2D>().enabled == false){
                pauseController.SetPauseGame(false);
            }
        }
        
    }

    void SetQuest(){
        
        // spawnerManager.StopInvoke();

        questIndex = Random.Range(0, questionDatas.Length);
        

        //Set Quest Text
        questText.text = questionDatas[questIndex].quest;

        for (int i = 0; i < choiceObjects.Length; i++)        
        {
            choiceObjects[i].SetActive(false);
        }


        for (int i = 0; i < questionDatas[questIndex].options.Length; i++)        
        {
            choiceObjects[i].transform.GetChild(0).GetComponent<Text>().text = questionDatas[questIndex].options[i];            
            choiceObjects[i].SetActive(true);            
            questText.gameObject.SetActive(true);
        }

        

        StartCoroutine(Pause());
        
    }


    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Profesor" && GetComponent<PlayerState>().GetState().ToString() != "Dash")   {
            GetComponent<PlayerState>().SwitchState("Idle");     
            professorObject = col.gameObject;
            SetQuest();
            convePanel.SetActive(true);
        }
        
    }

    public void Answering(int choiceIndex){
        convePanel.SetActive(false);
        

        if(choiceIndex == questionDatas[questIndex].answerIndex){
            coinData.value += 10;
            MissionManager.Instance.AddCoinPoint(50);
            SpawnGimmickEffect.Instance.SpawnGimmick(2);
            GetComponent<AudioSource>().PlayOneShot(clips[1]);
        } else {
            GetComponent<AudioSource>().PlayOneShot(clips[0]);
        }

        professorObject.GetComponent<BoxCollider2D>().enabled = false;
        pauseController.SetPauseGame(false);
        // spawnerManager.StartInvoke();
        StartCoroutine(AfterAnswer());
        
    }

    IEnumerator AfterAnswer(){        
        yield return new WaitForSeconds(0);
        GetComponent<PlayerState>().SwitchState("Run");

        yield return new WaitForSeconds(0.5f);
        Destroy(professorObject);
    }

    IEnumerator Pause(){        
        yield return new WaitForSeconds(0.5f);
        pauseController.PauseGame();
        
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
