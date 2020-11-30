using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHealth : MonoBehaviour, ICollectible
{

    public void Collect(){
        PlayerHealth.Instance.AddHealth(25);                
        AudioOneShooter.Instance.ShootClip(0);
        Destroy(this.gameObject);
    }
}
