using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour, ICollectible
{
    public void Collect(){              
        PlayerHealth.Instance.SubHealth(20);
        
        Destroy(this.gameObject);
    }
}
