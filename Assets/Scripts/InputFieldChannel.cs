using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InputFieldChannel : MonoBehaviour
{
    public event Action<string> OnSelectEvent = null;
    public event Action<string> OnDeselectEvent = null;
    public event Action<string> OnValueChangeEvent = null;
    public event Action<string> OnEnterEvent = null;

    private TMP_InputField inputField = null;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void OnSelect(string text)
    {
        OnSelectEvent?.Invoke(text);
    }

    public void OnDeselect(string text)
    {
        OnDeselectEvent?.Invoke(text);
    }

    public void OnValueChange(string text)
    {
        OnValueChangeEvent?.Invoke(text);
    }

    private void Update()
    {
        OnEnter();
    }

    private void OnEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            OnEnterEvent?.Invoke(inputField?.text);

            #region Reset Input Field
            inputField.text = "";
            inputField.ActivateInputField();
            #endregion
        }
    }
}
