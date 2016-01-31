using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();

    public AudioSource audioSource = null;
    public AudioSource musicSource = null;
    

    public void Play(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


    public void Play(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
    }


    public void PlayMusic(AudioClip clip)
    {
        Debug.Log("setting up music");
        if (musicSource.isPlaying) musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }
}
