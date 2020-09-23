using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectingItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyEffect(int itemType){
        if(GetComponent<PlayerState>().GetState().ToString() != "Dash"){
            switch (itemType)
            {
                case 0:
                    Debug.Log("Get Masker");
                    GetComponent<PlayerHealth>().AddMask();
                    AudioOneShooter.Instance.ShootClip(0);
                    break;
                case 1:
                    
                    Debug.Log("Get Hit");
                    GetComponent<PlayerHealth>().SubHealth(20);
                    GetComponent<PlayerHealth>().Hurting();
                    
                    break;
                case 2:
                    Debug.Log("Get Medic");
                    GetComponent<PlayerHealth>().AddHealth(20);                
                    AudioOneShooter.Instance.ShootClip(0);
                    break;
                case 3:
                    Debug.Log("Get Skateboard");
                    GetComponent<PlayerDash>().Dash("Skateboard");    
                    AudioOneShooter.Instance.ShootClip(0);            
                    break;
                case 4:
                    Debug.Log("Get Sepeda");
                    GetComponent<PlayerDash>().Dash("Sepeda");    
                    AudioOneShooter.Instance.ShootClip(0);            
                    break;
                case 5:
                    Debug.Log("Get Superheal");
                    // GetComponent<PlayerDash>().Dash("Sepeda");    
                    AudioOneShooter.Instance.ShootClip(0);            
                    break;
                default:
                    Debug.Log("Zero");
                    break;
            }        
        }

        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "CollectibleItem")   {
            ApplyEffect(col.gameObject.GetComponent<CollectibleItem>().GetType());
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "SmokerTrigger"){
            col.transform.parent.gameObject.GetComponent<EnemySmoking>().Smoking();
        }
    }
}
