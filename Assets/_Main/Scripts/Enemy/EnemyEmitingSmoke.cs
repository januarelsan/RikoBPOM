using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmitingSmoke : MonoBehaviour
{
    [SerializeField] private GameObject smokeItem;
    [SerializeField] private Transform ciggaratePos;
    
    public void EmittingSmoke(){
        Instantiate(smokeItem, ciggaratePos.position, ciggaratePos.rotation);
    }
}
