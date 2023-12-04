using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("按鈕音效")]
    public AudioClip ButtonASound;
    public AudioClip ButtonBSound;
    public AudioClip CatSound;
    
    [Header("特效音效")]
    public AudioClip Ability_Heal;
    public AudioClip Ability_twohit;
    public AudioClip Ability_DrawAAgain;
    public AudioClip Ability_CantHurt;
    public AudioClip Ability_bullettime;
    public AudioClip Ability_Boom;


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

    public void PlayAbility1Sound()
    {
        audioSource.PlayOneShot(Ability_Heal);
    }

    public void PlayAbility2Sound()
    {
        audioSource.PlayOneShot(Ability_Boom);
    }
    public void PlayAbility4Sound()
    {
        audioSource.PlayOneShot(Ability_twohit);
    }

    public void PlayAbility5Sound()
    {
        audioSource.PlayOneShot(Ability_CantHurt);
    }
    public void PlayAbility6Sound()
    {
        audioSource.PlayOneShot(Ability_bullettime);
    }

    public void PlayAbility7Sound()
    {
        audioSource.PlayOneShot(Ability_DrawAAgain);
    }
}
