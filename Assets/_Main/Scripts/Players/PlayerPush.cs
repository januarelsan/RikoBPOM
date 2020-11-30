using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    [SerializeField] private GameObject pushTrigger;
    
    
    public void Push(){
        if(GetComponent<PlayerState>().GetState().ToString() == "Run" || GetComponent<PlayerState>().GetState().ToString() == "Slide")
            StartCoroutine(Pushing());
    }

    IEnumerator Pushing()
    {
        
        // GetComponent<PlayerState>().SwitchState("Push");        
        // pushTrigger.SetActive(true);
        // yield return new WaitForSeconds(0.2f);
        
        // GetComponent<PlayerState>().SwitchState("Run");
        // pushTrigger.SetActive(false);

        GetComponent<PlayerState>().SwitchState("Push");        
        pushTrigger.SetActive(true);
        yield return new WaitForSeconds(0);
            
        
    }

    public void FinishPushing(){
        if(GetComponent<PlayerState>().GetState().ToString() == "Push")
            GetComponent<PlayerState>().SwitchState("Run");
        
        pushTrigger.SetActive(false);
    }
    
    
}
