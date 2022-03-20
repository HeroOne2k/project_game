using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionView : MonoBehaviour
{
    public TMP_Text questionNumberText;
    public TMP_Text questionContentText;
    public OptionPanel[] optionPanels;
    public QuestionResultView resultView;

    private Question currentQuestion;
    public void ShowQuestion(int index, Question question)
    {
        currentQuestion = question;
        questionNumberText.text = (index + 1).ToString();
        questionContentText.text = question.questionContent;

        ShowOptions(question);
    }
    private void ShowOptions(Question question)
    {
        for (int i = 0; i < optionPanels.Length; i++)
        {
            var isInRange = i < question.options.Length;
            optionPanels[i].gameObject.SetActive(isInRange);
            if (isInRange)
            {
                optionPanels[i].optionContentText.text = question.options[i];
            }
        }
    }

    public void OnOptionClicked(int index)
    {
        var isCorrect = currentQuestion.correctAnswer == index;
        if (isCorrect)
        {
            Scoring1.Score++;
        }
        resultView.Show(isCorrect, currentQuestion.correctAnswer);
        gameObject.SetActive(false);
    }
}
