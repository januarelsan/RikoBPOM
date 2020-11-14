using System.Collections;
using UnityEngine;
using UnityEngine.UI;
 
public class TypeWriter : MonoBehaviour {
 
    #pragma warning disable 0649 
    [SerializeField] private Text captionText; 
	[SerializeField] private float letterPause;
	[SerializeField] private AudioClip sound;
 
	[SerializeField] private string message;

    Coroutine writingCoroutine;

    private bool isWriting;
    
 	
    public void StartWriting(string message){
        this.message = message;
        captionText.text = "";
        writingCoroutine = null;
		writingCoroutine = StartCoroutine(TypeText());
    }

    public void FinishWriting(){

        if(isWriting){
            StopCoroutine(writingCoroutine);
            isWriting = false;            
            captionText.text = message;            
        } 

    }
 
	IEnumerator TypeText () {
        
        isWriting = true;
        
		foreach (char letter in message.ToCharArray()) {
			captionText.text += letter;
			if (sound)
				GetComponent<AudioSource>().PlayOneShot (sound);
				// yield return 0;
			yield return new WaitForSeconds (letterPause);
		
        }
        isWriting = false;              
	}

    public bool GetIsWriting(){
        return isWriting;
    }

    

    
}