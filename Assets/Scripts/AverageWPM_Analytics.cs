using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageWPM_Analytics : AnalyticsBase
{
    protected override void Awake()
    {
        base.Awake();
        slider.value = AnalyticsManager.Average_WPM;
        label.text = $"AVG {AnalyticsManager.Average_WPM} WPM";
    }

    protected override void OnTimerExit(int initialTime)
    {
        int value = (AnalyticsManager.TotalWords / initialTime + AnalyticsManager.Average_WPM) / AnalyticsManager.DataCount;
        Debug.Log(AnalyticsManager.Average_WPM);
        Debug.Log(AnalyticsManager.DataCount);
        slider.value = value;
        label.text = $"AVG {value} WPM";
        AnalyticsManager.Average_WPM = value;
    }
}
