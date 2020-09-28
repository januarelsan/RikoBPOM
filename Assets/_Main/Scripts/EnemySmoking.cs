﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmoking : MonoBehaviour
{
    [SerializeField] private GameObject smokeItem;
    [SerializeField] private Transform ciggaratePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmittingSmoke(){
        Instantiate(smokeItem, ciggaratePos.position, ciggaratePos.rotation);
    }

    public void Smoking(){
        GetComponent<Animator>().SetTrigger("Smoking");
    }
    
}