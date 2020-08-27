using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            transform.parent.GetChild(0).position = new Vector3(transform.parent.GetChild(0).position.x + (72*3), 1,0);
            transform.parent.GetChild(0).SetAsLastSibling();
        }
    }
}
