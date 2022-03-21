using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionContent;
    public string[] options;
    public int correctAnswer;
}

[System.Serializable]
public class QuestionCollection
{
    public Question[] collection;
}

[CreateAssetMenu]
public class QuestionCollectionAsset : ScriptableObject
{
    public QuestionCollection data;
}
