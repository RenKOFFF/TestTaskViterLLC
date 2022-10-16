using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePopup : MonoBehaviour
{
    private TextMeshProUGUI _textUI;

    private void Start()
    {
        _textUI = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        EndGame.OnEndGameWinEvent.AddListener(MakeWin);
        EndGame.OnEndGameLoseEvent.AddListener(MakeLose);
    }

    private void MakeWin()
    {
        Invoke(nameof(SetActive), 1f);
        _textUI.text = "онаедю";
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }

    private void MakeLose()
    {
        SetActive();
        _textUI.text = "ньхайю";
    }
}
