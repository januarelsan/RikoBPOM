using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmitingSmoke : MonoBehaviour
{
    [SerializeField] private GameObject smokeItem;
    [SerializeField] private Transform ciggaratePos;

    private GameObject smoke;
    
    public void EmittingSmoke(){
        smoke = Instantiate(smokeItem, ciggaratePos.position, ciggaratePos.rotation);
    }

    public void DestorySmoke(){
        Destroy(smoke);
    }
}
