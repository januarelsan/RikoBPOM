﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosterManager : MonoBehaviour
{
    [SerializeField] private Sprite[] posterSprites;
    [SerializeField] private Image posterImage;
    [SerializeField] private Slider loadingSlider;

    // Start is called before the first frame update
    void Start()
    {
        posterImage.sprite = posterSprites[Random.Range(0,posterSprites.Length)];
        StartCoroutine(Loading());
        StartCoroutine(ChangePoster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    IEnumerator ChangePoster(){
        posterImage.sprite = posterSprites[Random.Range(0,posterSprites.Length)];
		yield return new WaitForSeconds(2);
        // // posterImage.sprite = posterSprites[Random.Range(0,posterSprites.Length)];
		// yield return new WaitForSeconds(2);
        // posterImage.sprite = posterSprites[Random.Range(0,posterSprites.Length)];
		// yield return new WaitForSeconds(2);
        // posterImage.sprite = posterSprites[Random.Range(0,posterSprites.Length)];
		// yield return new WaitForSeconds(2);
        

    }
		

    IEnumerator Loading(){
        
        loadingSlider.value = Random.Range(31f,50f);
		yield return new WaitForSeconds(Random.Range(1f,2f));
        loadingSlider.value = Random.Range(51f,75f);
		yield return new WaitForSeconds(Random.Range(1f,2f));
        loadingSlider.value = Random.Range(76f,100f);
        yield return new WaitForSeconds(1);
        
        SceneController.Instance.GoToScene("IntroStory");

    }
}
