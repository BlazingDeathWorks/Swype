using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static List<string> WordLibrary { get; private set; }
    private const string originPath = @"D:\Users\Game Dev Storage\Game Dev Games\Typing Competition App\Assets\Word Library" + "/Library.txt";
    public static string LibraryFileName { get; private set; } = "/Library.txt";
    public static string LibraryPath { get; private set; } = null;
    public static string NewLibraryPath { get; private set; } = null;

    private void Awake()
    {
        NewLibraryPath = Application.persistentDataPath + @"\NewLibrary.txt";
        LibraryPath = Application.persistentDataPath + LibraryFileName;
        if(File.Exists(LibraryPath))
        File.Delete(LibraryPath);
        if (!File.Exists(LibraryPath))
        {
            File.Create(LibraryPath);
            string[] originTextFile = File.ReadAllLines(originPath);
            using (StreamWriter sw = new StreamWriter(LibraryPath))
            {
                foreach(string text in originTextFile)
                {
                    sw.WriteLine(text);
                }
            }
            Debug.Log("Create Successful");
        }
        ResetWordLibrary();
    }

    private static void ResetWordLibrary()
    {
        WordLibrary = new List<string>();
        WordLibrary.AddRange(File.ReadAllLines(LibraryPath));
    }

    public static string RandomString()
    {
        return WordLibrary[Random.Range(0, WordLibrary.Count)];
    }
}
