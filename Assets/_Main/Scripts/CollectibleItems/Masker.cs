using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masker : MonoBehaviour, ICollectible
{
    public void Collect(){      
        Debug.Log("Mask");  
        PlayerHealth.Instance.AddMask();
        AudioOneShooter.Instance.ShootClip(0);
        Destroy(this.gameObject);
    }
}
