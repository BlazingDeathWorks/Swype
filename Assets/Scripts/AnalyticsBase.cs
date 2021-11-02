using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class AnalyticsBase : MonoBehaviour
{
    [SerializeField] protected TimeManager timeManager = null;
    [SerializeField] protected InputFieldChannel inputFieldChannel = null;
    [SerializeField] protected Slider slider = null;
    [SerializeField] protected TMP_Text label = null;

    protected virtual void Awake()
    {
        if (timeManager == null) return;
        timeManager.OnTimerExitEvent += OnTimerExit;
        inputFieldChannel.OnSelectEvent += OnSelect;
    }

    protected abstract void OnTimerExit(int initialTime);
    protected virtual void OnSelect(string text)
    {

    }
}
