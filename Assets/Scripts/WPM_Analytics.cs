using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPM_Analytics : AnalyticsBase
{
    protected override void Awake()
    {
        base.Awake();
        slider.value = AnalyticsManager.Previous_WPM;
        label.text = $"{AnalyticsManager.Previous_WPM} WPM";
    }

    protected override void OnTimerExit(int initialTime)
    {
        int value = AnalyticsManager.TotalWords / initialTime;
        slider.value = value;
        label.text = $"{value} WPM";
        AnalyticsManager.Previous_WPM = value;
    }
}
