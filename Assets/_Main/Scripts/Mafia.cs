using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia : MonoBehaviour
{
    [SerializeField] private bool isSPG;
    [SerializeField] private ParticleSystem smokePush;
    [SerializeField] private AudioClip pushedClip;
    [SerializeField] private AudioClip pushedDeadClip;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    

    [SerializeField] private int live = 2;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pushed(){
        
        live--;
        if(live > 0){
            
            rigidbody2D.velocity = new Vector2(25,0);
            smokePush.Play();
            boxCollider2D.enabled = false;
            GetComponent<AudioSource>().PlayOneShot(pushedClip);
            StartCoroutine(StopVelocity());    

        }else{
            smokePush.Play();
            rigidbody2D.velocity = new Vector2(25,5);
            boxCollider2D.enabled = false;
            rigidbody2D.AddTorque(125);
            MissionManager.Instance.AddEnemyPoint(1);            
            SpawnGimmickEffect.Instance.SpawnGimmick(2);

            if(!isSPG)
                MissionManager.Instance.AddCoinPoint(200);            
            else
                MissionManager.Instance.AddCoinPoint(75);            

            StartCoroutine(DestroyMafia());            
        }

    }

    IEnumerator DestroyMafia(){
        boxCollider2D.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(pushedClip);
        GetComponent<AudioSource>().PlayOneShot(pushedDeadClip);
        yield return new WaitForSeconds(2f);
        
        Destroy(this.gameObject);
    }

    IEnumerator StopVelocity(){
        yield return new WaitForSeconds(1f);
        rigidbody2D.velocity = Vector2.zero;
        boxCollider2D.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col){        
        if(col.gameObject.tag == "PushTrigger")   {
            
            // MissionManager.Instance.AddEnemyPoint(1);
            // MissionManager.Instance.AddCoinPoint(10);
            // SpawnGimmickEffect.Instance.SpawnGimmick(2);
            // Destroy(gameObject);
            Pushed();
        }

        if(col.gameObject.tag == "DashCollider")   {
            
            smokePush.Play();
            rigidbody2D.velocity = new Vector2(25,5);
            rigidbody2D.AddTorque(125);
            MissionManager.Instance.AddEnemyPoint(1);
            MissionManager.Instance.AddCoinPoint(25);            
            SpawnGimmickEffect.Instance.SpawnGimmick(2);
            StartCoroutine(DestroyMafia());  
        }
        
    }

    
}
