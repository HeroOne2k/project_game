using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionforPlayer : MonoBehaviour
{
    public GameObject question;
    public int coinValue;

    void Start()
    {
        question.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            question.SetActive(true);
            question.GetComponent<QuestionView>().coin = gameObject;
        }
    }
}
