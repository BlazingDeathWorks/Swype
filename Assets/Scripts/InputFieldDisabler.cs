using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldDisabler : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager = null;
    private TMP_InputField tmp_InputField = null;

    private void Awake()
    {
        tmp_InputField = GetComponent<TMP_InputField>();
        timeManager.OnTimerExitEvent += initialTime =>
        {
            tmp_InputField.DeactivateInputField(true);
            tmp_InputField.text = "";
        };
    }
}
