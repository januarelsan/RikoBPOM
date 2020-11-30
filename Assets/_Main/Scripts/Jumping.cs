using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float playerUpwardForce;
    public AudioClip jumpClip;

    private Rigidbody2D rb2;
    private bool isGrounded = true;
    

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
            isGrounded = false;
            GetComponent<PlayerState>().SwitchState("Jump");
            rb2.AddForce(new Vector3(0,playerUpwardForce,0), ForceMode2D.Impulse);
            GetComponent<AudioSource>().PlayOneShot(jumpClip);
        }
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground" && !isGrounded && GetComponent<PlayerState>().GetState().ToString() == "Jump"){
            isGrounded = true;
            GetComponent<PlayerState>().SwitchState("Run");
        }
    }
    
}
