using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : MonoBehaviour, ICollectible
{
    public void Collect(){      
        Debug.Log("Get Sepeda");
        PlayerDash.Instance.Dash("Sepeda");    
        AudioOneShooter.Instance.ShootClip(0);     
        Destroy(this.gameObject);
    }
}
