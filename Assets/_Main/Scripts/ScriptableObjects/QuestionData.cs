using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/Trivia Question")]
public class QuestionData : ScriptableObject
{
    public string quest;
    public string[] options;
    public int answerIndex;
}
