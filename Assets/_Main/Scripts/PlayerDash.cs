using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    
    [SerializeField] private GameObject smokeExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dash(string dashName){
        StartCoroutine(Dashing(dashName));
        
    }

    IEnumerator Dashing(string dashName)
    {
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        GetComponent<PlayerState>().SwitchState("Dash");
        GetComponent<Animator>().SetTrigger(dashName);
        yield return new WaitForSeconds(10);
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        GetComponent<PlayerState>().SwitchState("Default");
        GetComponent<Animator>().SetTrigger("FinishDash");
    }

    
}
