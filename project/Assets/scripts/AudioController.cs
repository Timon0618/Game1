using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSourceAmb;
    private AudioSource _audioSourceSound;

    private void Awake()
    {
        foreach (var source in GetComponents<AudioSource>())
        {
            if (source.clip != null)
            {
                _audioSourceAmb = source;
            }
            else
            {
                _audioSourceSound = source;
            }
        }
    }

    void Start()
    {
        SetMusicEnabledState();
        SetMusicVolume();
        SetSoundEnabledState();
        SetSoundVolume();
    }

    public void SetMusicEnabledState()
    {
        _audioSourceAmb.enabled = DataContainer.IsMusicOn;
       
    }

    public void SetMusicVolume()
    {
        _audioSourceAmb.volume = DataContainer.MusicVolume;
    }

    public void SetSoundEnabledState()
    {
        _audioSourceSound.enabled = DataContainer.IsSoundOn;

    }

    public void SetSoundVolume()
    {
        _audioSourceSound.volume = DataContainer.SoundsVolume;
    }

    public void PlaySound(AudioClip _clip, float pitchMin = 9f, float pitchMax = 1.1f, bool destroyed = false, Vector3 destroyedPosition = new Vector3())
    {
        if (!destroyed)
            _audioSourceSound.PlayOneShot(_clip, DataContainer.SoundsVolume);
        else
            AudioSource.PlayClipAtPoint(_clip, destroyedPosition, DataContainer.SoundsVolume);
    }
}
