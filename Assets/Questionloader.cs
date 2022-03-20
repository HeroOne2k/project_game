using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Questionloader : MonoBehaviour
{
    public int numberOfQuestions;
    public QuestionView questionView;
    //public ReportView reportView;
    public string url;
    public string jsonData;

    private List<Question> shuffledQuestions = new List<Question>();
    private int currentQuestionIndex;
    private QuestionCollection collectionData;
    //private string jsonData;

    private void Start()
    {
        //collectionData = JsonUtility.FromJson<QuestionCollection>(jsonData);
        collectionData = JsonUtility.FromJson<QuestionCollection>(jsonData);
        GenerateShuffledQuestions();
        Scoring1.TotalScore = shuffledQuestions.Count;
        Scoring1.Score = 0;
        //reportView.gameObject.SetActive(false);
        ShowCurrentQuestion();
    }

    private void GenerateShuffledQuestions()
    {
        var limit = Mathf.Min(numberOfQuestions, collectionData.collection.Length);

        var questionDeck = new List<Question>(collectionData.collection);
        shuffledQuestions.Clear();
        for (int i = 0; i < limit; i++)
        {
            var index = Random.Range(0, questionDeck.Count);
            shuffledQuestions.Add(questionDeck[index]);
            questionDeck.RemoveAt(index);
        }
    }
    private void ShowCurrentQuestion()
    {
        var currentQuestion = shuffledQuestions[currentQuestionIndex];

        questionView.ShowQuestion(currentQuestionIndex, currentQuestion);
    }

    public void ShowNextQuestion()
    {
        if (currentQuestionIndex + 1 < shuffledQuestions.Count)
        {
            currentQuestionIndex++;
            ShowCurrentQuestion();
        }
        //else
        //{
        //    reportView.gameObject.SetActive(true);
        //}
    }
}
