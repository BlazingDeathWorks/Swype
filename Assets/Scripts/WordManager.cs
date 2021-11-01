using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static List<string> WordLibrary { get; private set; }
    private const string originPath = @"D:\Users\Game Dev Storage\Game Dev Games\Typing Competition App\Assets\Word Library" + libraryFileName;
    private const string libraryFileName = "/Library.txt";
    public static string LibraryPath { get; private set; } = null;

    private void Awake()
    {
        LibraryPath = Application.persistentDataPath + libraryFileName;
        if (!File.Exists(LibraryPath))
        {
            File.Create(LibraryPath);
            Debug.Log("Create Successful");
        }
        ResetWordLibrary();
    }

    private static void ResetWordLibrary()
    {
        WordLibrary = new List<string>();
        WordLibrary.AddRange(File.ReadAllLines(originPath));
    }

    public static string RandomString()
    {
        return WordLibrary[Random.Range(0, WordLibrary.Count)];
    }
}
