using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : Singleton<PlayerDash>
{
    
    [SerializeField] private GameObject smokeExplosion;
    [SerializeField] private BoxCollider2D dashCollider;
    [SerializeField] private AudioClip dashClip;

    [SerializeField] private Button[] uiButtons;
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
        DisableUI(false);
    }

    public void DisableUI(bool value){
        foreach (Button btn in uiButtons)
        {
            btn.enabled = value;
        }
    }

    IEnumerator Dashing(string dashName)
    {
        GetComponent<AudioSource>().clip = dashClip;
        GetComponent<AudioSource>().Play();
        dashCollider.enabled = true;
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        GetComponent<PlayerState>().SwitchState(dashName);
        GetComponent<Animator>().SetTrigger(dashName);
        GetComponent<BoxCollider2D>().enabled = false;


        yield return new WaitForSeconds(10);

        GetComponent<BoxCollider2D>().enabled = true;

        yield return new WaitForSeconds(1);


        GetComponent<AudioSource>().Stop();
        dashCollider.enabled = false;
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        GetComponent<PlayerState>().SwitchState("Run");
        DisableUI(true);
        
    }

    
}
