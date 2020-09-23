using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : Singleton<Jumping>
{
    public float playerUpwardForce;

    private Rigidbody2D rb2;
    

    void Awake(){
        rb2 = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump(){
        if(GetComponent<PlayerState>().GetState().ToString() == "Run" || GetComponent<PlayerState>().GetState().ToString() == "Slide" ){
            GetComponent<PlayerState>().SwitchState("Jump");
            rb2.AddForce(new Vector3(0,playerUpwardForce,0), ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("Jump");
        }
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground"){
            GetComponent<PlayerState>().SwitchState("Default");
        }
    }
    
}
