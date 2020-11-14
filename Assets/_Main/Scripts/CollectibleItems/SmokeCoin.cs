using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmokeCoin : MonoBehaviour, ICollectible
{
    [SerializeField] private AudioClip lostCoinClip;
    // Start is called before the first frame update
    public void Collect(){      
        Debug.Log("Get Hit by SmokeCoin");       
        PlayerHealth.Instance.SubHealth(0);         
        StartCoroutine(SpawnGimmick());
        
        
        MissionManager.Instance.SubCoinPoint(5);
        GetComponent<AudioSource>().PlayOneShot(lostCoinClip);
        
        
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator SpawnGimmick(){
        Debug.Log("Spawn GImmict");        
        yield return new WaitForSeconds(0.5f);
        SpawnGimmickEffect.Instance.SpawnGimmick(5);
        Destroy(this.gameObject);
    }
}
