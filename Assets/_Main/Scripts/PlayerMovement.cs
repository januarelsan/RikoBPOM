using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float defSpeed;
    private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = defSpeed;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime,0,0);
        if(GetComponent<PlayerHealth>().GetIsHurt()){
            speed = 0;
        } else if(GetComponent<PlayerDash>().GetIsDashing()){
            if(speed < 50)
                speed += 0.2f;
            else    
                speed = 50;
        } else
        {
            speed = defSpeed;   
        }

    }
}
