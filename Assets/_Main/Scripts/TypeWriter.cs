using System.Collections;
using UnityEngine;
using UnityEngine.UI;
 
public class TypeWriter : MonoBehaviour {
 
    [SerializeField] private Text captionText; 
	[SerializeField] private float letterPause;
	[SerializeField] private AudioClip sound;
 
	[SerializeField] private string message;

    Coroutine writingCoroutine;

    private bool isWriting;
    private bool isWritingFinish;
 
	// Use this for initialization
	void Start () {
		
		captionText.text = "";
		writingCoroutine = StartCoroutine(TypeText());
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

    public void FinishWriting(){

        if(isWriting && !isWritingFinish){
            StopCoroutine(writingCoroutine);
            isWriting = false;
            isWritingFinish = true;
            captionText.text = message;
            
        } else {
            ToGameScene();
        }

    }

    public void ToGameScene(){
        SceneController.Instance.GoToScene("Game");
    }
}