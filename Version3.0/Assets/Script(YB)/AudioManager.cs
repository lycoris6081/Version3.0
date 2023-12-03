using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioClip ButtonASound;
    public AudioClip ButtonBSound;
    public AudioClip CatSound;

    public AudioMixer audioMixer;    // 進行控制的Mixer變量
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void SetMasterVolume(float volume)    // 控制主音量的函數
    {
        audioMixer.SetFloat("MasterVolume", volume);
        // MasterVolume爲我們暴露出來的Master的參數
    }

    public void SetMusicVolume(float volume)    // 控制背景音樂音量的函數
    {
        audioMixer.SetFloat("MusicVolume", volume);
        // MusicVolume爲我們暴露出來的Music的參數
    }

    public void SetSoundEffectVolume(float volume)    // 控制音效音量的函數
    {
        audioMixer.SetFloat("SoundEffectVolume", volume);
        // SoundEffectVolume爲我們暴露出來的SoundEffect的參數
    }

    public void PlayButtonASound()
    {
        audioSource.PlayOneShot(ButtonASound);
    }
    public void PlayButtonBSound()
    {
        audioSource.PlayOneShot(ButtonBSound);
    }

    public void PlayCatSound()
    {
        audioSource.PlayOneShot(CatSound);
    }
}
