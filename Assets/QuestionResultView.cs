using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class QuestionResultView : MonoBehaviour
{
    public GameObject correctPanel;
    public GameObject incorrectPanel;
    public UnityEvent onClose;

    public TMP_Text correctAnswerText;

    public void Show(bool isCorrect, int correctAnswer)
    {
        gameObject.SetActive(true);
        correctPanel.SetActive(isCorrect);
        incorrectPanel.SetActive(!isCorrect);
        correctAnswerText.text = $"{(char)('A' + correctAnswer)}";
        Invoke(nameof(Hide), 2f);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        onClose.Invoke();
    }
}
