using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image maskerOnHealtImage;

    private float health = 100;
    private int masked;

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
    }

    public void AddHealth(float value){        
        health += value;

        if(health > 100)
            health = 100;
    }

    public void SubHealth(float value){

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
