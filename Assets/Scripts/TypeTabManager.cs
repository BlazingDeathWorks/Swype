using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeTabManager : MonoBehaviour
{
    [SerializeField] Button[] buttons = null;
    [SerializeField] InputFieldChannel inputFieldChannel = null;
    [SerializeField] TimeManager timeManager;

    private void Awake()
    {
        inputFieldChannel.OnSelectEvent += OnSelect;
        inputFieldChannel.OnDeselectEvent += OnDeselect;
        timeManager.OnTimerExitEvent += OnTimerExit;
    }

    private void OnSelect(string text)
    {
        foreach(Button button in buttons)
        {
            button.interactable = false;
        }
    }

    private void OnTimerExit(int initialTime)
    {
        foreach (Button button in buttons)
        {
            if (button == null) continue;
            button.interactable = true;
        }
    }

    private void OnDeselect(string text)
    {
        OnTimerExit(0);
    }
}
