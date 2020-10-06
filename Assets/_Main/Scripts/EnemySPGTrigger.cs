using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySPGTrigger : MonoBehaviour, ITriggerable
{
    [SerializeField] private GameObject ciggarateItem;
    [SerializeField] private Transform ciggaratePos;
    

    public void Trigger(){
        SpawnCiggarate();
    }

    public void SpawnCiggarate(){
        Instantiate(ciggarateItem, ciggaratePos.position, ciggaratePos.rotation);
    }

    
}
