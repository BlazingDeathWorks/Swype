using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    [SerializeField] StringLabelController timeLabel, modeLabel;
    [SerializeField] InputFieldChannel inputFieldChannel = null;
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
                Debug.Log(e.Message);
                return 0;
            }
        }
    }
    string Mode { get => modeLabel.Text; }
    float time = 0;
    string timeFormatted = null;
    bool canPlay = false;
    const string ENDLESS = "Endless";
    const int SECONDS = 60;

    private void Awake()
    {
        tmp_Text = GetComponentInChildren<TMP_Text>();
        inputFieldChannel.OnSelectEvent += OnSelect;
        inputFieldChannel.OnDeselectEvent += OnDeselect;
        timeLabel.OnUpdateEvent += () => UpdateText();
    }

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        if (canPlay)
        {
            //FormatTime();
            return;
        }
    }

    private void FormatTime()
    {
        time -= Time.deltaTime;
        timeFormatted = $"{(int)time / SECONDS}:{Mathf.Abs(SECONDS - ((int)time / SECONDS))}{Mathf.Abs(SECONDS - ((int)time / SECONDS))}";
        tmp_Text.text = timeFormatted;
    }

    private void UpdateText()
    {
        tmp_Text.text = InitialTime.ToString();
        time = InitialTime * SECONDS;
    }

    private void OnSelect(string text)
    {
        canPlay = Mode != ENDLESS;
    }

    private void OnDeselect(string text)
    {
        canPlay = false;
    }

}
