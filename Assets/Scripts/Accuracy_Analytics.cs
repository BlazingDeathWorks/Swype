using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accuracy_Analytics : AnalyticsBase
{
    protected override void Awake()
    {
        base.Awake();
        slider.value = AnalyticsManager.Previous_Accuracy;
        label.text = $"{AnalyticsManager.Previous_Accuracy}% Accuracy";
    }

    protected override void OnTimerExit(int initialTime)
    {
        int inaccuracy = (int)((float)AnalyticsManager.TotalMisses / AnalyticsManager.TotalWords * 100);
        int value = 100 - inaccuracy;
        slider.value = value;
        label.text = $"{value}% Accuracy";
        AnalyticsManager.Previous_Accuracy = value;
    }
}
