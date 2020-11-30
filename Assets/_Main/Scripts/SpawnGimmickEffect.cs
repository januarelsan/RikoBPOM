using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGimmickEffect : Singleton<SpawnGimmickEffect>
{
    [SerializeField] private GameObject gimmickEffectPrefab;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnGimmick(int index){        
        GameObject gimmick = Instantiate(gimmickEffectPrefab, player.position, player.rotation, player);
        gimmick.GetComponent<GimmickEffect>().SetSprite(index);
    }


}
