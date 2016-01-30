using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();

    public AudioSource audioSource = null;
    

    public void Play(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


    public void Play(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
    }
}
