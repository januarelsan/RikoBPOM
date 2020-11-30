using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuild : MonoBehaviour, IDamageable
{
    [SerializeField] private bool warung;
    [SerializeField] private bool market;
    [SerializeField] private bool plang;
    [SerializeField] private bool pabrik;



    [SerializeField] private Sprite[] damageSprites;
    [SerializeField] private Sprite[] destroySprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int live;
    
    void Start(){
        
    }

    public void Damage(){
        live--;
        if(live > 0)
        {
           spriteRenderer.sprite = damageSprites[live];            
        }else{            
            // GetComponent<Animator>().enabled = true;
            // GetComponent<Animator>().SetTrigger("Destroy");
            StartCoroutine(DestroyAnim());
            
        }
    }

    IEnumerator DestroyAnim()
    {
        int i;
        i = 0;
        while (i < destroySprites.Length)
        {
            spriteRenderer.sprite = destroySprites[i];
            i++;
            yield return new WaitForSeconds(0.1f);            
        }
        yield return new WaitForSeconds(0.2f);
        MissionManager.Instance.AddEnemyPoint(1);       
        SpawnGimmickEffect.Instance.SpawnGimmick(2);
        PlayerState ps = FindObjectOfType<PlayerState>();


        if(plang)
            MissionManager.Instance.AddCoinPoint(20);     
        if(warung)
            MissionManager.Instance.AddCoinPoint(25);     
        if(market)
            MissionManager.Instance.AddCoinPoint(50);     
        if(pabrik)
            MissionManager.Instance.AddCoinPoint(150);     
        
        Destroy(this.gameObject);   

        if(ps.GetState().ToString() != "Dash"){
            ps.SwitchState("Run");       
            SpawnerManager.Instance.StartSpawn();
            PlayerAttack pa = FindObjectOfType<PlayerAttack>();
            pa.AfterAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D col){        
        

        if(col.gameObject.tag == "DashCollider")   {        
            StartCoroutine(DestroyAnim());                        
        }
        
    }

}
