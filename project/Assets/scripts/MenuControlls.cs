using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControlls : MonoBehaviour
{
    [SerializeField] private GameObject _selectLevelPanel;

    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Slider _SoundVolumeSlider;
    [SerializeField] private Toggle _SoundToggle;

    [SerializeField] private AudioController audioController;


    private void Start()
    {
        _musicVolumeSlider.value = DataContainer.MusicVolume;
        _musicToggle.isOn = DataContainer.IsMusicOn;
        _SoundVolumeSlider.value = DataContainer.SoundsVolume;
        _SoundToggle.isOn = DataContainer.IsSoundOn;
    }

    public void PlayButtonClick()
    {
        //SceneManager.LoadScene(DataContainer.LastConptetedLevel + 1);

        _selectLevelPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitButtonClick()                           
    {
        Application.Quit();
    }

    public void SetMusicVolume()
    {
        DataContainer.MusicVolume = _musicVolumeSlider.value;
        audioController.SetMusicVolume();
    }

    public void SetMusicEnabledState()
    {
        DataContainer.IsMusicOn = _musicToggle.isOn;
        audioController.SetMusicEnabledState();
    }

    public void SetSoundVolume()
    {
        DataContainer.SoundsVolume = _SoundVolumeSlider.value;
        audioController.SetMusicVolume();
    }

    public void SetSoundEnabledState()
    {
        DataContainer.IsSoundOn = _SoundToggle.isOn;
        audioController.SetMusicEnabledState();
    }

}
