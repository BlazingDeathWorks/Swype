using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnalyticsManager
{
    public static int TotalWords { get => totalWords; }
    public static int TotalMisses { get => totalMisses; }
    public static int DataCount { get => PlayerPrefs.GetInt(DATACOUNT); set => PlayerPrefs.SetInt(DATACOUNT, value); }
    public static int Average_WPM { get => PlayerPrefs.GetInt(AVG_WPM); set => PlayerPrefs.SetInt(AVG_WPM, value); }
    public static int Previous_WPM { get => PlayerPrefs.GetInt(PREVIOUS_WPM); set => PlayerPrefs.SetInt(PREVIOUS_WPM, value); }
    public static int Previous_Accuracy { get => PlayerPrefs.GetInt(PREVIOUS_ACCURACY); set => PlayerPrefs.SetInt(PREVIOUS_ACCURACY, value); }

    private static string AVG_WPM = "AVG_WPM";
    private static string DATACOUNT = "DATACOUNT";
    private static string PREVIOUS_WPM = "PREVIOUS_WPM";
    private static string PREVIOUS_ACCURACY = "PREVIOUS_ACCURACY";

    private static int totalWords = 0;
    private static int dataCount = 0;
    private static int totalMisses = 0;

    public static void AddToTotalWords()
    {
        totalWords++;
    }

    public static void AddToTotalMisses()
    {
        totalMisses++;
    }

    public static void AddToDataCount()
    {
        dataCount = DataCount;
        dataCount++;
        PlayerPrefs.SetInt(DATACOUNT, dataCount);
    }
}
