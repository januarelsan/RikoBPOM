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
        } 
    }

    public void AfterAttack(){
        // GetComponent<PlayerState>().SwitchState("Run");
    }
    
    void OnTriggerEnter2D(Collider2D col){                
        if(col.GetComponent<IDamageable>() != null){
            nearDamageable = col.GetComponent<IDamageable>();            
            GetComponent<PlayerState>().SwitchState("Idle");
        }                       
    }

    void OnTriggerExit2D(Collider2D col){            
        if(nearDamageable != null){
            nearDamageable = null;            
        }                   
    }
}
