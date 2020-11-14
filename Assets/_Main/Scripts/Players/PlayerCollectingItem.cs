using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectingItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
                

    void OnTriggerEnter2D(Collider2D col){        
        if(GetComponent<PlayerState>().GetState().ToString() != "Dash"){

            if(col.GetComponent<ICollectible>() != null){                
                col.GetComponent<ICollectible>().Collect();
            }
        }
        
        if(col.gameObject.tag == "SmokerTrigger"){
            if(col.GetComponent<ITriggerable>() != null){
                
                col.GetComponent<ITriggerable>().Trigger();
            }
            
        }
    }
}
