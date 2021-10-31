using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StringLabelController : MonoBehaviour
{
    public event Action OnUpdateEvent;
    [SerializeField] string[] labels = null;
    [SerializeField] private TMP_Text tmp_Text;
    public string Text { get => tmp_Text.text; private set => tmp_Text.text = value; }
    int index = 0;

    public void NextLabel()
    {
        if (labels == null || !tmp_Text || index + 1 >= labels.Length) return;
        index++;
        UpdateText();
    }

    public void PreviousLabel()
    {
        if (labels == null || !tmp_Text || index - 1 < 0) return;
        index--;
        UpdateText();
    }

    public void UpdateText()
    {
        Text = labels[index];
        OnUpdateEvent?.Invoke();
    }
}
