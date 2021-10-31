using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class WordManager
{
    public static string[] WordLibrary { get; private set; } = File.ReadAllLines(@"D:\Users\Game Dev Storage\Game Dev Games\Typing Competition App\Assets\Word Library\Library.txt");

    public static string RandomString()
    {
        return WordLibrary[Random.Range(0, WordLibrary.Length)];
    }
}
