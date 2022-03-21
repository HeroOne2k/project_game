using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReportView : MonoBehaviour
{
    public TMP_Text scoreText;
    private void OnEnable()
    {
        scoreText.text = $"{Scoring1.Score}/{Scoring1.TotalScore}";
    }
}
