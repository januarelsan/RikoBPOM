using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject pushTrigger;

    private IDamageable nearDamageable;
    


    
    public void Attack(){
        if(nearDamageable != null){
            nearDamageable.Damage();
            GetComponent<PlayerState>().SwitchState("Attack");
            GetComponent<Animator>().SetTrigger("Attack");
            
        } else{

            if(GetComponent<PlayerState>().GetState().ToString() == "Run"){                
                StartCoroutine(Pushing());

            }
        }

        
    }

    

    public void AfterAttack(){
        GetComponent<PlayerState>().SwitchState("Default");
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

    void OnTriggerEnter2D(Collider2D col){
        
        
        if(col.GetComponent<IDamageable>() != null){
            nearDamageable = col.GetComponent<IDamageable>();            
        }       
                
    }

    void OnTriggerExit2D(Collider2D col){
            
        if(nearDamageable != null){
            nearDamageable = null;            
        }           
        
    }
}
