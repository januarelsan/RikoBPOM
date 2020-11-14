using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour, ICollectible
{
    public void Collect(){      
        Debug.Log("Get Hit by Fire");
        PlayerHealth.Instance.SubHealth(10);
        
        Destroy(this.gameObject);
    }
}
