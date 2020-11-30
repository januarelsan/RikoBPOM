using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia : MonoBehaviour
{
    [SerializeField] private bool isSPG;
    [SerializeField] private ParticleSystem smokePush;
    [SerializeField] private AudioClip pushedClip;
    [SerializeField] private AudioClip pushedDeadClip;

    [SerializeField] private EnemySPGTrigger enemySPGTrigger;

    
    
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    

    [SerializeField] private int live;
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
            
            if(rigidbody2D)
                rigidbody2D.velocity = new Vector2(25,0);

            if(smokePush)
                smokePush.Play();

            if(boxCollider2D)
                boxCollider2D.enabled = false;

            if(GetComponent<AudioSource>())
                GetComponent<AudioSource>().PlayOneShot(pushedClip);

            StartCoroutine(StopVelocity());    

        }else{
            if(smokePush)
                smokePush.Play();

            if(rigidbody2D)
                rigidbody2D.velocity = new Vector2(25,5);

            if(boxCollider2D)
                boxCollider2D.enabled = false;

            if(rigidbody2D)
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
        if(boxCollider2D)
            boxCollider2D.enabled = false;

        if(GetComponent<AudioSource>()){
            GetComponent<AudioSource>().PlayOneShot(pushedClip);
            GetComponent<AudioSource>().PlayOneShot(pushedDeadClip);
        }
        yield return new WaitForSeconds(2f);
        
        Destroy(this.gameObject);
    }

    IEnumerator StopVelocity(){
        yield return new WaitForSeconds(2f);

        if(enemySPGTrigger){
            enemySPGTrigger.SpawnCiggarate();            
        }

        // yield return new WaitForSeconds(0.5f);

        if(boxCollider2D)
                boxCollider2D.enabled = true;

        if(rigidbody2D){

            rigidbody2D.velocity = Vector2.zero;
        }
        if(boxCollider2D){
            
            
            boxCollider2D.enabled = true;
            
        }
    }

    void OnTriggerEnter2D(Collider2D col){    

        

        if(col.gameObject.tag == "PushTrigger")   {                    
            Pushed();
        }

        if(col.gameObject.tag == "DashCollider")   {

            Debug.Log("Mafia Kena Dash");
            
            if(smokePush)
                smokePush.Play();
                
            if(rigidbody2D){
                rigidbody2D.velocity = new Vector2(25,5);
                rigidbody2D.AddTorque(125);
            }

            MissionManager.Instance.AddEnemyPoint(1);
            

            if(!isSPG)
                MissionManager.Instance.AddCoinPoint(200);            
            else
                MissionManager.Instance.AddCoinPoint(75);   

            SpawnGimmickEffect.Instance.SpawnGimmick(2);
            StartCoroutine(DestroyMafia());  
        }
        
    }
}
    

