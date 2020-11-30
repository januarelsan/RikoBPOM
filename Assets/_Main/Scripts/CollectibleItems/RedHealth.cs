using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHealth : MonoBehaviour, ICollectible
{

    public void Collect(){
        PlayerHealth.Instance.AddHealth(10);                
        AudioOneShooter.Instance.ShootClip(0);
        Destroy(this.gameObject);
    }
}
