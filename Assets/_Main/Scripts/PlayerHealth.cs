﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HutongGames.PlayMaker;

public class PlayerHealth : Singleton<PlayerHealth>
{
    #pragma warning disable 0649
    [SerializeField] private Slider healthSlider;
    [SerializeField] private PlayMakerFSM healthOnSliderFSM;
    [SerializeField] private Image maskerOnHealtImage;

    private float health = 100;
    private int masked;

    private bool isDead;

    [SerializeField] private GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
                        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        if(masked > 0){
            maskerOnHealtImage.enabled = true;
        } else {
            maskerOnHealtImage.enabled = false;
        }

        if(health <= 0 && !isDead){
            GetComponent<PlayerState>().SwitchState("Die");
            Debug.Log(GetComponent<PlayerState>().GetState().ToString());
            GetComponent<Animator>().SetTrigger("Die");
            isDead = true;
            GameManager.Instance.GameOver();
        }
        
    }

    public float GetHealth(){
        return health;
    }

    public void Hurting(){
        GetComponent<PlayerState>().SwitchState("Hurt");
        GetComponent<Animator>().SetTrigger("Hurt");
    }

    public void AfterHurting(){
        GetComponent<PlayerState>().SwitchState("Default");
    }   

    public void AddHealth(float value){        
        health += value;

        if(health > 100)
            health = 100;
    }

    public void SubHealth(float value){

        healthOnSliderFSM.SendEvent("PunchScale");
        
        if(masked > 0){
            health -= value/2;    
        }else{
            health -= value;
            masked--;
        }
        
        if(health <= 0)
        {

        }
    }

    public void AddMask(){
        
        masked = 3;
        
    }

    public void SubMask(){
        masked--;        
    }

    



}
