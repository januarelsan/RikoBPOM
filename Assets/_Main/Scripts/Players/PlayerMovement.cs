﻿using System.Collections;
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
        
        if(GetComponent<PlayerState>().GetState().ToString() == "Hurt"){
            speed = 0;
        } else if (GetComponent<PlayerState>().GetState().ToString() == "Idle"){
                speed = 0;
        } else if(GetComponent<PlayerState>().GetState().ToString() == "Dash"){
            if(speed < 20)
                speed += 0.2f;
            else    
                speed = 20;
        } else if (GetComponent<PlayerState>().GetState().ToString() == "Push"){
                speed = 15;
        } else if (GetComponent<PlayerState>().GetState().ToString() == "Toss"){
                speed = 0;
        } else if (GetComponent<PlayerState>().GetState().ToString() == "Attack"){
                speed = 0;
        } else
        {
            speed = defSpeed;   
        }

        if (GetComponent<PlayerHealth>().GetHealth() <= 0){
            speed = 0;
        } 

    }

    
}
