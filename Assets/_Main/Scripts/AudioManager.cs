using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager playerInstance;

    void Awake(){
        DontDestroyOnLoad (this);
            
        if (playerInstance == null) {
            playerInstance = this;
        } else {
            DestroyObject(gameObject);
        }
    }

    void Update(){
        
        if(GameData.Instance.AudioOn == 0){
            if(GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Pause();
        } else {
            if(!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }       
    }
}
