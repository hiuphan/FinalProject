using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField]private AudioMixer mainMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        } else {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mainMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        mainMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    private void LoadVolume() {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetMusicVolume();
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}
