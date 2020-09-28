using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    [SerializeField] private GameObject pushTrigger;
    
    
    public void Push(){
        if(GetComponent<PlayerState>().GetState().ToString() == "Run")
        StartCoroutine(Pushing());
    }

    IEnumerator Pushing()
    {
        
        GetComponent<PlayerState>().SwitchState("Push");
        GetComponent<Animator>().SetTrigger("Push");
        pushTrigger.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        GetComponent<PlayerState>().SwitchState("Default");
        pushTrigger.SetActive(false);
        
    }
    
    
}
