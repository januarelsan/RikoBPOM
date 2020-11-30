using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendToss : MonoBehaviour
{
    [SerializeField] private GameObject glow;
    private bool isTossed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SuperHealing(){
        glow.SetActive(true);
        Toss();
        GetComponent<EnemyEmitingSmoke>().DestorySmoke();
    }

    public void Toss(){
        GetComponent<Animator>().SetTrigger("Toss");   
        GetComponent<BoxCollider2D>().enabled = false;
        
        isTossed = true;
    }

    IEnumerator EnableBoxcollider(){
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    public bool GetIsTossed(){
        return isTossed;
    }
}
