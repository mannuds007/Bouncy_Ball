using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clip-----")]

    public AudioClip bgm;
    public AudioClip pause;
    public void Start(){
        musicSource.clip = bgm;
        musicSource.Play();
    }
    public void PauseSFX( AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
        musicSource.Pause();
    }
    public void ResumeSFX( AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
        musicSource.Play();
    }
    
}
