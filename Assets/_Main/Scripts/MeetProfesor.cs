using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetProfesor : MonoBehaviour
{
    [SerializeField] private GameObject convePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Profesor")   {
            GetComponent<PlayerState>().SwitchState("Idle");
            GetComponent<Animator>().SetTrigger("Idle");
            convePanel.SetActive(true);
        }
        
    }

    public void Answering(){
        convePanel.SetActive(false);
        GetComponent<PlayerState>().SwitchState("Default");
        GetComponent<Animator>().SetTrigger("Run");
    }
}
