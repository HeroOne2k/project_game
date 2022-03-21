using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectByMouse : MonoBehaviour
{
    public SelectByKey keySelector;

    private void Start()
    {
        for (int i = 0; i < keySelector.buttons.Length; i++)
        {
            AddListenerToButton(i);
        }
    }

    private void AddListenerToButton(int index)
    {
        var button = keySelector.buttons[index];
        var trigger = button.gameObject.AddComponent<EventTrigger>();

        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(_ => keySelector.CurrentOption = index);

        trigger.triggers.Add(entry);
    }

}
