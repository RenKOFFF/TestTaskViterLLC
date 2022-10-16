using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        VolumeManager.OnMusicVolumeChangedEvent.AddListener(SetValue);
    }

    private void Start()
    {
        SetValue(VolumeManager.instanse.MusicVolume);
        _slider.onValueChanged.AddListener(VolumeManager.instanse.SetVolume);
    }

    private void SetValue(float value)
    {
        if (_slider.value == value) return;

        _slider.value = value;
    }
}
