using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuperHealing : Singleton<PlayerSuperHealing>
{
        
    [SerializeField] private AudioClip healingClip;
    private GameObject[] smokers;
    private GameObject[] smokeItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SuperHealing(){
        smokers = null;
        smokers = GameObject.FindGameObjectsWithTag("Smoker");
        if(smokers.Length > 0){

            bool allTossed = true;
            
            for (int i = 0; i < smokers.Length; i++)
            {
                if(smokers[i].GetComponent<FriendToss>().GetIsTossed()){

                }else{
                    allTossed = false;
                    smokers[i].GetComponent<FriendToss>().SuperHealing();
                    MissionManager.Instance.AddFriendPoint(1);
                    SpawnGimmickEffect.Instance.SpawnGimmick(1);
                }
            }

            if(!allTossed){
                GameData.Instance.SuperhealingAmount--;
                GetComponent<AudioSource>().PlayOneShot(healingClip);
            }

            smokeItems = GameObject.FindGameObjectsWithTag("SmokeItem");
            for (int i = 0; i < smokeItems.Length; i++)
            {
                Destroy(smokeItems[i]);
            }
        }
        
    }
    
}
