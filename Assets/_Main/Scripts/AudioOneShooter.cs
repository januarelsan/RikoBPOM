using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOneShooter : Singleton<AudioOneShooter>
{
    [SerializeField] private AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootClip(int index){
        GetComponent<AudioSource>().PlayOneShot(clips[index]);
    }
}
