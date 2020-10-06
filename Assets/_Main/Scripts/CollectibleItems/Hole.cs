using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour, ICollectible
{
    public void Collect(){      
        Debug.Log("Get Hit by Hole");
        PlayerHealth.Instance.SubHealth(100);
        PlayerHealth.Instance.Hurting();
        Destroy(this.gameObject);
    }
}
