using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour
{
    private bool isNearSmoker;
    private GameObject nearestSmoker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toss(){
        if(isNearSmoker){
            Debug.Log("Toss");
            
            GetComponent<PlayerState>().SwitchState("Toss");
            GetComponent<Animator>().SetTrigger("Toss");   

            if(nearestSmoker != null)                 {
                nearestSmoker.GetComponent<FriendToss>().Toss();
            }
            
        
        }

    }

    public void FinishToss(){
        GetComponent<PlayerState>().SwitchState("Default");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Smoker")   {
            isNearSmoker = true;
            nearestSmoker = col.gameObject;
        }        
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Smoker")   {
            isNearSmoker = false;
        }        
    }
}
