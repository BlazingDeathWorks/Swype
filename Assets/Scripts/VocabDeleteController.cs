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
    }

    private void OnValueChange(string text)
    {
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

                if (File.Exists(WordManager.LibraryPath))
                {
                    File.Delete(WordManager.LibraryPath);
                }
                File.Move(WordManager.NewLibraryPath, WordManager.LibraryPath);
                Debug.Log("Successfully Deleted");
            }
        }
    }
}
