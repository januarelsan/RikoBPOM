using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMarket : MonoBehaviour, IDamageable
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(){
        GetComponent<Animator>().SetTrigger("Destroy");
    }

}
