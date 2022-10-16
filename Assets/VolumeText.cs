using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VolumeText : MonoBehaviour
{
    private TextMeshProUGUI _textUI;

    private void Awake()
    {
        _textUI = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        VolumeManager.OnMusicVolumeChangedEvent.AddListener(SetTextValue);
    }

    private void Start()
    {
        SetTextValue(VolumeManager.instanse.MusicVolume);
    }

    private void SetTextValue(float valume)
    {
        _textUI.text = $"ÇÂÓÊ: {Mathf.Round(valume * 100)}%";
    }
}
