using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour, ICollectible
{
    public void Collect(){      
        Debug.Log("Get Skateboard");
        PlayerDash.Instance.Dash("Skateboard");    
        AudioOneShooter.Instance.ShootClip(0); 
        Destroy(this.gameObject);    
    }
}
