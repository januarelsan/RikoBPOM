using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : Singleton<PlayerDash>
{
    
    [SerializeField] private GameObject smokeExplosion;
    [SerializeField] private BoxCollider2D dashCollider;
    [SerializeField] private AudioClip dashClip;
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
        GetComponent<AudioSource>().clip = dashClip;
        GetComponent<AudioSource>().Play();
        dashCollider.enabled = true;
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        GetComponent<PlayerState>().SwitchState("Dash");
        GetComponent<Animator>().SetTrigger(dashName);
        yield return new WaitForSeconds(10);
        GetComponent<AudioSource>().Stop();
        dashCollider.enabled = false;
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        GetComponent<PlayerState>().SwitchState("Run");
        
    }

    
}
