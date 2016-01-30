using UnityEngine;
using System.Collections;

public class SoundObject : InteractibleObject
{
    public AudioSource soundEffect = null;
    private bool playing = false;

    public override void StartInteraction()
    {
            Interact();
    }


    public override void StopInteraction()
    {
        
    }


    protected override void Interact()
    {
        if (soundEffect.isPlaying) soundEffect.Stop();
        soundEffect.Play();
    }
}
