using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSliding : Singleton<PlayerSliding>
{

    [SerializeField] private AudioClip slideClip;    
    private Vector2 defaultColSize;    
    private Vector2 defaultColOffSet;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultColSize = GetComponent<BoxCollider2D>().size;
        defaultColOffSet = GetComponent<BoxCollider2D>().offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerState>().GetState().ToString() != "Slide"){
            GetComponent<BoxCollider2D>().size = defaultColSize;
            GetComponent<BoxCollider2D>().offset = defaultColOffSet;    
        }
    }

    public void Slide(){   
        if(GetComponent<PlayerState>().GetState().ToString() == "Run"){            
            // Debug.Log("Press Slide Button");
            GetComponent<PlayerState>().SwitchState("Slide");    
            GetComponent<AudioSource>().PlayOneShot(slideClip);
            GetComponent<BoxCollider2D>().size = new Vector2(2,1);
            GetComponent<BoxCollider2D>().offset = new Vector2(0,-2.5f);
        }
    }
    
    public void FinishSlide(){
        // Debug.Log("Finish Slide");
        // GetComponent<BoxCollider2D>().size = defaultColSize;
        // GetComponent<BoxCollider2D>().offset = defaultColOffSet;

        if(GetComponent<PlayerState>().GetState().ToString() == "Slide")
            GetComponent<PlayerState>().SwitchState("Run"); 
    }

    

    
    
}
