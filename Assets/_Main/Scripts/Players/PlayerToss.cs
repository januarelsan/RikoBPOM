using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour
{
    [SerializeField]private FriendData friendData;
    [SerializeField]private AudioClip tossClip;
    [SerializeField]private AudioClip friendClip;
    private bool isNearSmoker;
    private bool isTossing;
    private GameObject nearestSmoker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toss(){
        if(GetComponent<PlayerState>().GetState().ToString() == "Run" || GetComponent<PlayerState>().GetState().ToString() == "Slide"){            
            if(isNearSmoker){            
                if(nearestSmoker != null && !isTossing){                      
                    isTossing = true;       
                    friendData.value++;
                    MissionManager.Instance.AddFriendPoint(1);
                    GetComponent<PlayerState>().SwitchState("Toss");  
                    GetComponent<AudioSource>().PlayOneShot(tossClip);
                    GetComponent<AudioSource>().PlayOneShot(friendClip);
                    nearestSmoker.GetComponent<FriendToss>().Toss();
                    SpawnGimmickEffect.Instance.SpawnGimmick(1);
                }            
            }        
        }
    }

    
    public void PlayerFinishToss(){        
        GetComponent<PlayerState>().SwitchState("Run");
        isTossing = false;        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Smoker")   {
            isNearSmoker = true;
            nearestSmoker = col.gameObject;
        }        
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Smoker")   {
            isNearSmoker = false;
        }        
    }
}
