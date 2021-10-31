using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

#region WordType
public enum WordType
{
    Active, Secondary, Inactive
}
#endregion
public class Word : MonoBehaviour
{
    #region Fields
    public WordType Type;
    public TMP_Text TextMeshPro {get; private set;} = null;

    public string Text { get; private set; }
    public RectTransform rect { get; private set; } = null;
    #endregion

    #region CallBack methods
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        TextMeshPro = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        NextWord();
    }
    #endregion

    #region Public Methods
    public bool CheckWord(string text)
    {
        return text.TrimEnd(' ') == Text;
    }

    public IEnumerator Relocate(Vector2 value, float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
        rect.position = value;
    }
    #endregion

    #region Private Methods
    private void UpdateTextMeshPro()
    {
        TextMeshPro.text = Text;
    }

    private void NextWord()
    {
        Text = WordManager.RandomString();
        UpdateTextMeshPro();
    }
    #endregion
}
