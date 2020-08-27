using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float playerUpwardForce;

    private Rigidbody2D rb2;
    private bool jumping;

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
        if(!jumping){
            rb2.AddForce(new Vector3(0,playerUpwardForce,0), ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("Jump");
            jumping = true;
        }
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground"){
            jumping = false;
        }
    }
}
