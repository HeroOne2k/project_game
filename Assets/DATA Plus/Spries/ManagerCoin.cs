using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerCoin : MonoBehaviour
{
    public static ManagerCoin instance;
    public TextMeshProUGUI Text;
    int score;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScoreCoin(int coinValue)
    {
        score += coinValue;
        Text.text = " " + score.ToString();
    }
}
