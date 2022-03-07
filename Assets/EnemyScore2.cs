using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore2 : MonoBehaviour
{
    public int score;
    public Health health;

    private void OnValidate() => health = GetComponent<Health>();

    void Start() => health.onDead.AddListener(AddScore);

    private void AddScore() => Scoring.Instance.Score += score * 100;
}
