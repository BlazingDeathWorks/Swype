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
        inputFieldChannel.OnDeselectEvent += (text) => DeactiveFeedback();
    }

    private void OnEnable()
    {
        DeactiveFeedback();
    }

    private void DeactiveFeedback()
    {
        goodText.SetActive(false);
        badText.SetActive(false);
    }

    private void OnValueChange(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            DeactiveFeedback();
            return;
        }
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
        string[] lines = File.ReadAllLines(WordManager.LibraryPath);
        using (StreamWriter writer = new StreamWriter(WordManager.LibraryPath))
        {
            foreach(string line in lines)
            {
                writer.WriteLine(line);
            }
            writer.WriteLine(text);
        }
        DeactiveFeedback();
    }
}
