using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VocabDeleteController : MonoBehaviour
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
        if (!WordManager.WordLibrary.Contains(text))
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
        WordManager.WordLibrary.Remove(text);
        string[] textFile = File.ReadAllLines(WordManager.LibraryPath);
        using (StreamReader sr = new StreamReader(WordManager.LibraryPath))
        {
            using (StreamWriter sw = new StreamWriter(WordManager.NewLibraryPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (text == line)
                    {
                        continue;
                    }
                    sw.WriteLine(line);
                }

                sw.Dispose();
                sr.Dispose();
                if (File.Exists(WordManager.LibraryPath))
                {
                    File.Delete(WordManager.LibraryPath);
                }
                File.Move(WordManager.NewLibraryPath, WordManager.LibraryPath);
            }
        }
        DeactiveFeedback();
    }
}
