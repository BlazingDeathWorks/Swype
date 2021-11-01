using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    public event Action<int> OnTimerExitEvent;
    [SerializeField] StringLabelController timeLabel, modeLabel;
    [SerializeField] InputFieldChannel inputFieldChannel = null;
    [SerializeField] bool resetAnalytics = false;
    private TMP_Text tmp_Text = null;
    int InitialTime
    {
        get
        {
            try
            {
                return int.Parse(timeLabel.Text);
            }
            catch(NullReferenceException e)
            {
                Debug.LogError(e.Message);
                return 1;
            }
        }
    }
    string Mode { get => modeLabel.Text; }
    string TimeFormatted { get => $"{(int)time / SECONDS}:{ (int)time % SECONDS / 10}{(int)time % SECONDS % 10}"; }
    float time = 0;
    bool canPlay = false;
    const string ENDLESS = "Endless";
    const int SECONDS = 60;

    private void Awake()
    {
        tmp_Text = GetComponentInChildren<TMP_Text>();
        inputFieldChannel.OnSelectEvent += OnSelect;
        inputFieldChannel.OnDeselectEvent += OnDeselect;
        timeLabel.OnUpdateEvent += ResetText;

        #region RESET ANALYTICS
        if (resetAnalytics)
        {
            AnalyticsManager.Previous_WPM = 0;
            AnalyticsManager.Previous_Accuracy = 0;
            AnalyticsManager.DataCount = 0;
            AnalyticsManager.Average_WPM = 0;
        }
        #endregion
    }

    private void Update()
    {
        if (canPlay)
        {
            FormatTime();
            CheckTime();
            return;
        }
    }

    private void CheckTime()
    {
        if(time <= 0)
        {
            AnalyticsManager.AddToDataCount();
            OnTimerExitEvent?.Invoke(InitialTime);
            ResetText();
        }
    }

    private void FormatTime()
    {
        time -= Time.deltaTime;
        tmp_Text.text = TimeFormatted;
    }

    private void ResetText()
    {
        canPlay = false;
        time = InitialTime * SECONDS;
        tmp_Text.text = TimeFormatted;
    }

    private void OnSelect(string text)
    {
        canPlay = Mode != ENDLESS;
    }

    private void OnDeselect(string text)
    {
        ResetText();
    }

}
