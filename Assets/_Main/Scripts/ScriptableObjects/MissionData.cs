using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionData", menuName = "ScriptableObjects/Mission Data")]
public class MissionData : ScriptableObject
{
    public int episode;
    public int level;
    public string description = "Jaga ibu agar terhindar dari rokok & lancar dalam persalinan bayinya.";
    public int enemy;
    public int friend;
    public int coin;
    
}
