using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Health health;
    public Image hpValueImage;
    public bool isPersistance;

    private void Start()
    {
        health.onHealthChanged.AddListener(OnHpChanged);
        OnHpChanged();

        gameObject.SetActive(isPersistance);
    }
    public void OnHpChanged()
    {
        hpValueImage.fillAmount = (float)health.HealthPoint / health.maxHealthPoint;

        if (!isPersistance)
        {
            ShowInAWhile();
        }
    }

    private void ShowInAWhile()
    {
        Show();
        CancelInvoke();
        Invoke(nameof(Hide), 1f);
    }

    private void Show() => gameObject.SetActive(true);
    private void Hide() => gameObject.SetActive(false);
}