using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VocabEnterController : MonoBehaviour
{
    [SerializeField] private InputFieldChannel inputFieldChannel = null;
    [SerializeField] private GameObject goodText, badText;
    bool canSubmit = false;

    private void Awake()
    {
        inputFieldChannel.OnValueChangeEvent += OnValueChange;
        inputFieldChannel.OnEnterEvent += OnEnter;
    }

    private void OnValueChange(string text)
    {
        if (WordManager.WordLibrary.Contains(text))
        {
            goodText.SetActive(false);
            badText.SetActive(true);
            canSubmit = false;
            return;
        }
        canSubmit = true;
        badText.SetActive(false);
        goodText.SetActive(true);
    }

    private void OnEnter(string text)
    {
        if (string.IsNullOrEmpty(text) || !canSubmit) return;
        WordManager.WordLibrary.Add(text);
        using (StreamWriter writer = new StreamWriter(WordManager.LibraryPath))
        {
            writer.WriteLine(text);
        }
    }
}
