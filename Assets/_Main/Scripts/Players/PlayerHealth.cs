using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HutongGames.PlayMaker;

public class PlayerHealth : Singleton<PlayerHealth>
{
    #pragma warning disable 0649
    [SerializeField] private Slider healthSlider;
    [SerializeField] private AudioClip hurtClip;

    [SerializeField] private PlayMakerFSM healthOnSliderFSM;
    [SerializeField] private ParticleSystem smokeParticle;
    
    private float health = 100;
    
    private bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
                        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        
        if(health <= 0 && !isDead){
            GetComponent<PlayerState>().SwitchState("Die");            
            
            isDead = true;
            GameManager.Instance.GameOver();
        }
        
    }

    public float GetHealth(){
        return health;
    }

    
    public void AfterHurting(){
        Debug.Log("After Hurt");
        GetComponent<PlayerState>().SwitchState("Run");
    }   

    public void AddHealth(float value){        
        health += value;

        if(health > 100)
            health = 100;

        SpawnGimmickEffect.Instance.SpawnGimmick(0);
    }

    public void SubHealth(float value){

        healthOnSliderFSM.SendEvent("PunchScale");
        
        if(value > 0)
            Hurting();
        else    
            OnlyHurting();


        if(PlayerMask.Instance.GetOnMask()){
            health -= value/2;    
        }else{
            health -= value;            
        }        
        
    }

    public void SubHealthByHole(float value){

        healthOnSliderFSM.SendEvent("PunchScale");
        FallingToHole();
        health -= value;      
                        
    }

    void Hurting(){
        GetComponent<PlayerState>().SwitchState("Hurt");        
        SpawnGimmickEffect.Instance.SpawnGimmick(3);
        GetComponent<AudioSource>().PlayOneShot(hurtClip);
    }

    void OnlyHurting(){
        GetComponent<PlayerState>().SwitchState("Hurt");        
        // SpawnGimmickEffect.Instance.SpawnGimmick(3);
    }

    void FallingToHole(){
        smokeParticle.Play();
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

}
