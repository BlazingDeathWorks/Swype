using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeTabManager : MonoBehaviour
{
    [SerializeField] Button[] buttons = null;
    [SerializeField] InputFieldChannel inputFieldChannel = null;

    private void Awake()
    {
        inputFieldChannel.OnSelectEvent += OnSelect;
        inputFieldChannel.OnDeselectEvent += OnDeselect;
    }

    private void OnSelect(string text)
    {
        foreach(Button button in buttons)
        {
            button.interactable = false;
        }
    }

    private void OnDeselect(string text)
    {
        foreach(Button button in buttons)
        {
            button.interactable = true;
        }
    }
}
