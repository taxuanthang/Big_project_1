using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RectTransform SoundPanel;

    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
    }
    public void Start()
    {
        SoundPanel.transform.localScale = Vector3.zero;
    }
    public void OpenSetting()
    {
        SoundPanel.LeanScale(Vector3.one, 0.5f);
    }
    public void CloseSetiing()
    {
        SoundPanel.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }
    public void Exit2Menu()
    {
        AudioManager.instance.musicSource.Stop();
        Navigation.instance.NavigationMainScene();
    }
}
