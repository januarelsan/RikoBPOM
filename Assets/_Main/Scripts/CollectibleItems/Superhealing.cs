using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superhealing : MonoBehaviour, ICollectible
{
    
    public void Collect(){  
            
        Debug.Log("Get Superheal");
        PlayerSuperHealing.Instance.SuperHealing();
        AudioOneShooter.Instance.ShootClip(0);    
        Destroy(this.gameObject);
    }
}
