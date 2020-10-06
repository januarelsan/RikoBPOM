using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelHistoryData", menuName = "ScriptableObjects/Level History Data")]
public class LevelHistoryData : ScriptableObject
{
    public int episode;
    public int level;
    public int stars;
    public int enemy;
    public int friend;
    public int coin;
    public bool opened;
}
