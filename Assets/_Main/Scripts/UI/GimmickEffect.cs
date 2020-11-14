using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickEffect : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite(int index){
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    IEnumerator DestroyEffect(){
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
