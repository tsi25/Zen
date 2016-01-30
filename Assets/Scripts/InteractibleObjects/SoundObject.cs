using UnityEngine;
using System.Collections;

public class SoundObject : InteractibleObject
{
    public AudioClip audioClip;

    private bool playing = false;

    public override void StartInteraction()
    {
            Interact();
    }


    protected override void Interact()
    {
        if(audioClip != null) GameManager.Retrieve<SoundManager>().Play(audioClip);
    }
}
