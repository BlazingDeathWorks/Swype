using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] StringLabelController[] stringLabelControllers = null;

    private void Start()
    {
        if (stringLabelControllers == null) return;
        foreach(StringLabelController stringLabelController in stringLabelControllers)
        {
            stringLabelController.UpdateText();
        }
    }
}
