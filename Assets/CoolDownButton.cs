using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CoolDownButton : MonoBehaviour
{
    public Button button;
    public float duration;
    public Image skillIcon;

    private float lastTime;
    private bool isCoolinngDown;
    public void OnButtonClicked()
    {
        button.interactable = false;
        isCoolinngDown = true;
        lastTime = Time.time;
    }

    private void Update()
    {
        if (!isCoolinngDown) return;
        var elapsedTime = Time.time - lastTime;
        if (elapsedTime >= duration)
        {
            isCoolinngDown = false;
            EnableButton();
        }
        else
        {
            skillIcon.fillAmount = elapsedTime / duration;
        }
    }

    private void EnableButton() => button.interactable = true;
    private void OnValidate() => button = GetComponent<Button>();

}
