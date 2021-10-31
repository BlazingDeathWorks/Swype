using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StringLabelController : MonoBehaviour
{
    public event Action OnUpdateEvent = null;
    [SerializeField] string[] labels = null;
    [SerializeField] GameObject parent = null;
    public string Text { get => tmp_Text.text; private set => tmp_Text.text = value; }
    private TMP_Text tmp_Text;
    int index = 0;

    private void Awake()
    {
        tmp_Text = GetComponent<TMP_Text>();
        UpdateText(index);
        parent.SetActive(false);
    }

    public void NextLabel()
    {
        if (labels == null || !tmp_Text || index + 1 >= labels.Length) return;
        UpdateText(++index);
    }

    public void PreviousLabel()
    {
        if (labels == null || !tmp_Text || index - 1 < 0) return;
        UpdateText(--index);
    }

    private void UpdateText(int index)
    {
        Text = labels[index];
        OnUpdateEvent?.Invoke();
    }
}
