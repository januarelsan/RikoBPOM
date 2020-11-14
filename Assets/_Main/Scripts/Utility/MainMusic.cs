using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    private static MainMusic playerInstance;

    [SerializeField] private AudioClip GameClip;
    [SerializeField] private AudioClip GeneralClip;

    void Awake(){
        DontDestroyOnLoad (this);
            
        if (playerInstance == null) {
            playerInstance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Update(){
        
        // Debug.Log("Music is: " + GameData.Instance.AudioOn);

        if(SceneController.Instance.GetSceneLoaded() == "Game"){
            GetComponent<AudioSource>().clip = GameClip;
            if(!GameManager.Instance.GetIsPlaying()){
               GetComponent<AudioSource>().volume = 0.1f; 
            }else{
                GetComponent<AudioSource>().volume = 1f; 
            }

        }else if(SceneController.Instance.GetSceneLoaded() == "ResultStory"){            
            GetComponent<AudioSource>().volume = 0f; 
        }else{
            GetComponent<AudioSource>().clip = GeneralClip;
            GetComponent<AudioSource>().volume = 1f; 
        }
        
        if(GameData.Instance.AudioOn == 0){
            if(GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Pause();
        } else {
            if(!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }
        

        
    }
    
    
}
