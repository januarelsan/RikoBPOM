using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmokingTrigger : MonoBehaviour, ITriggerable
{
    
    public void Trigger(){
        
        Smoking();
    }
    
    public void Smoking(){
        transform.parent.GetComponent<Animator>().SetTrigger("Smoking");
        Destroy(this.gameObject);
    }
    
}
