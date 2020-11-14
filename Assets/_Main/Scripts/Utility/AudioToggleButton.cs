using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggleButton : MonoBehaviour
{
    [SerializeField] private Sprite[] audioSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        transform.GetComponent<Image>().sprite = audioSprites[GameData.Instance.AudioOn];                
    }

    public void ToogleAudio(){
        if(GameData.Instance.AudioOn == 1){
            GameData.Instance.AudioOn = 0;
        } else {
            GameData.Instance.AudioOn = 1;
        }
    }
}
