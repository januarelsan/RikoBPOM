using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuperHealing : MonoBehaviour
{
    public GameObject glow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SuperHealing(){
        StartCoroutine(_SuperHealing());
    }
    IEnumerator _SuperHealing(){
        glow.SetActive(true);
        yield return new WaitForSeconds(2f);
        glow.SetActive(false);
    }
}
