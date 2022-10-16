using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager instanse;
    public float MusicVolume { get; private set; }
    public AudioSource MusicAudioSource { get; private set; }

    private static readonly string _isStartNewGamePlayerPrefsName = "IsStartNewGame";
    private static readonly string _musicVolumePlayerPrefsName = "MusicVolume";
    private int _isStartNewGameValue;

    public static UnityEvent<float> OnMusicVolumeChangedEvent = new UnityEvent<float>();

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    void Start()
    {
        MusicAudioSource = GetComponent<AudioSource>();

        _isStartNewGameValue = PlayerPrefs.GetInt(_isStartNewGamePlayerPrefsName);

        if (_isStartNewGameValue == 0)
        {
            MusicVolume = 0.75f;

            PlayerPrefs.SetFloat(_musicVolumePlayerPrefsName, MusicVolume);
            PlayerPrefs.SetInt(_isStartNewGamePlayerPrefsName, -1);
        }
        else
        {
            MusicVolume = PlayerPrefs.GetFloat(_musicVolumePlayerPrefsName);
        }

        SetVolume(MusicVolume);
    }
    public void SetVolume(float volume)
    {
        MusicVolume = volume;
        PlayerPrefs.SetFloat(_musicVolumePlayerPrefsName, MusicVolume);

        MusicAudioSource.volume = MusicVolume;

        OnMusicVolumeChangedEvent.Invoke(MusicVolume);
    }
}
