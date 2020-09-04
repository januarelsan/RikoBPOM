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
        
        switch (itemType)
        {
            case 0:
                Debug.Log("Get Masker");
                GetComponent<PlayerHealth>().AddMask();
                break;
            case 1:
                Debug.Log("Get Hit");
                GetComponent<PlayerHealth>().SubHealth(20);
                break;
            default:
                Debug.Log("Zero");
                break;
        }        

        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "CollectibleItem")   {
            ApplyEffect(col.gameObject.GetComponent<CollectibleItem>().GetType());
            Destroy(col.gameObject);
        }
    }
}
