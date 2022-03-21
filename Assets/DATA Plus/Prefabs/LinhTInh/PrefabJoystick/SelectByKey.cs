using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectByKey : MonoBehaviour
{
    public Button[] buttons;

    private int currentOptionValue;
    public int CurrentOption
    {
        get => currentOptionValue;
        set
        {
            currentOptionValue = value;
            ShowCurrentSelection();
        }
    }

    private void Start() => CurrentOption = 0;

    public void ShowCurrentSelection()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.color = (i == CurrentOption) ? Color.green : Color.white;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectNextOption();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectPreviousOption();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SubmitCurrentOption();
        }
    }
    private void SelectNextOption()
    {
        var nextOption = CurrentOption + 1;
        if (nextOption >= buttons.Length
            || !buttons[nextOption].isActiveAndEnabled)
        {
            nextOption = 0;
        }
        CurrentOption = nextOption;
    }
    private void SelectPreviousOption()
    {
        var previousOption = CurrentOption - 1;
        if (previousOption < 0)
        {
            previousOption = buttons.Length - 1;
            while (!buttons[previousOption].isActiveAndEnabled)
            {
                previousOption--;
            }
        }
        CurrentOption = previousOption;
    }

    private void SubmitCurrentOption()
    {
        buttons[CurrentOption].onClick.Invoke();
        CurrentOption = 0;
    }

}
   
