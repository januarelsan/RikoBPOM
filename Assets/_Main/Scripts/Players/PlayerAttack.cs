using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject pushTrigger;

    private IDamageable nearDamageable;
    
    
    public void Attack(){        
        if(nearDamageable != null ){            
            nearDamageable.Damage();
            GetComponent<PlayerState>().SwitchState("Attack");                        
        } else
        {
            Debug.Log("No near");
        }
    }

    public void AfterAttack(){
        if(nearDamageable != null)
            nearDamageable = null; 
    }
    
    void OnTriggerEnter2D(Collider2D col){                
        if(col.GetComponent<IDamageable>() != null && GetComponent<PlayerState>().GetState().ToString() != "Dash"){
            nearDamageable = col.GetComponent<IDamageable>();            
            GetComponent<PlayerState>().SwitchState("Idle");
            SpawnerManager.Instance.StopSpawn();
            Debug.Log("Enter");
        }                       
    }

    void OnTriggerExit2D(Collider2D col){            
        // if(nearDamageable != null){
        //     nearDamageable = null;            
        //     SpawnerManager.Instance.StartSpawn();
        //     Debug.Log("Exit");
        // }                   
    }
}
