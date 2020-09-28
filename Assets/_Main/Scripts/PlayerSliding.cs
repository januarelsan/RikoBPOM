using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSliding : Singleton<PlayerSliding>
{
        
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slide(){   
        if(GetComponent<PlayerState>().GetState().ToString() == "Run"){
            GetComponent<PlayerState>().SwitchState("Slide");
            GetComponent<Animator>().SetTrigger("Slide");                    
            GetComponent<BoxCollider2D>().size = new Vector2(2,1);
            GetComponent<BoxCollider2D>().offset = new Vector2(0,-2.5f);
        }
    }

    public void FinishSlide(){
        // Debug.Log("Finish Slide");
        GetComponent<PlayerState>().SwitchState("Default");
        GetComponent<BoxCollider2D>().size = new Vector2(2.5f,5);
        GetComponent<BoxCollider2D>().offset = new Vector2(0,-0.5f);
    }

    

    
    
}
