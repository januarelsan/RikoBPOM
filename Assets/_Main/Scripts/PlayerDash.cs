using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private bool isDashing;
    [SerializeField] private GameObject smokeExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dash(){
        StartCoroutine(Dashing());
        
    }

    IEnumerator Dashing()
    {
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        isDashing = true;
        GetComponent<Animator>().SetTrigger("Skateboard");
        yield return new WaitForSeconds(10);
        smokeExplosion.GetComponent<ParticleSystem>().Play();
        isDashing = false;
        GetComponent<Animator>().SetTrigger("FinishSkateboard");
    }

    public bool GetIsDashing(){
        return isDashing;
    }
}
