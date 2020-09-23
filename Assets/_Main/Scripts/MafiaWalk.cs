using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaWalk : MonoBehaviour
{
    [SerializeField] private float defSpeed;
    private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = defSpeed;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime,0,0);        
    }
}
