using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputFieldChannel inputFieldChannel = null;
    [SerializeField] List<Word> words = new List<Word>();
    [SerializeField] [Range(0, 5)] float time = 3;
    [SerializeField] WordInitialDataManager wordInitialDataManager = null;
    Word activeWord = null;

    private void Awake()
    {
        inputFieldChannel.OnEnterEvent += OnEnter;
    }

    private void OnEnter(string text)
    {
        activeWord = words[0];
        if (activeWord.CheckWord(text))
        {
            TransitionWords();
            ChangeActiveWord();
        }
    }

    private void ChangeActiveWord()
    {
        words.Remove(activeWord);
        words.Add(activeWord);
    }

    private void TransitionWords()
    {
        if (wordInitialDataManager.initialWordPos.Length < 3) return;
        foreach(Word word in words)
        {
            switch (word.Type)
            {
                case WordType.Active:
                    #region Active
                    //Translate
                    word.transform.LeanMoveLocalX(-800, time).setEaseOutQuad();

                    //Change Type
                    word.Type = WordType.Inactive;
                    StartCoroutine(word.Relocate(wordInitialDataManager.initialWordPos[2], time, () => { word.gameObject.SetActive(false); word.transform.LeanScale(wordInitialDataManager.initialWordSize[2], time); }));
                    #endregion
                    break;

                case WordType.Secondary:
                    #region Secondary
                    //Translate
                    word.transform.LeanMoveLocal(wordInitialDataManager.initialWordPos[0], time);
                    word.transform.LeanScale(wordInitialDataManager.initialWordSize[0], time);

                    //Change Type
                    word.Type = WordType.Active;
                    #endregion
                    break;

                default:
                    #region Inactive
                    //Enable
                    word.gameObject.SetActive(true);

                    //Translate
                    word.transform.LeanMoveLocal(wordInitialDataManager.initialWordPos[1], time);
                    word.transform.LeanScale(wordInitialDataManager.initialWordSize[1], time);

                    //Change Type
                    word.Type = WordType.Secondary;
                    #endregion
                    break;
            }
        }
    }
}
