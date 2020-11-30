using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySPGTrigger : MonoBehaviour, ITriggerable
{
    [SerializeField] private bool IsMafia;
    [SerializeField] private GameObject smokeItem;
    [SerializeField] private GameObject ciggarateItem;
    [SerializeField] private Transform ciggaratePos;
    

    public void Trigger(){
        SpawnCiggarate();
        Debug.Log("SpawnCiggarate");
    }

    public void SpawnCiggarate(){
        Instantiate(ciggarateItem, ciggaratePos.position, ciggaratePos.rotation);
        // Destroy(this.gameObject);
        GetComponent<BoxCollider2D>().enabled = false;

        if(IsMafia)
            StartCoroutine(DoubleSpawn());
        
    }

    IEnumerator DoubleSpawn(){
        yield return new WaitForSeconds(1f);
        Instantiate(smokeItem, ciggaratePos.position, ciggaratePos.rotation);
    }

    

    
}
