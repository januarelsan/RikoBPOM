using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRelativePosition : MonoBehaviour
{
    
    [SerializeField] private Camera cam;

    void Start()
    {
        


        // Vector3 screenPos = cam.ScreenToWorldPoint(new Vector3(325, 720, 10));
        // transform.position = screenPos;
        // Debug.Log("target is " + screenPos.x + " pixels from the left");

        Vector3 screenPos = cam.ScreenToWorldPoint(new Vector3(Screen.width/9, Screen.height/2, 10));
        transform.position = screenPos;

        cam.GetComponent<CameraFollow>().enabled = true;


    }

    void Update()
    {
        
        
    }
}
