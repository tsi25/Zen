using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicPlayer : StarableObject
{
    public List<AudioClip> musicClips = new List<AudioClip>();
    public float secondaryDelay = 1f;

    public List<GameObject> silhouettes = new List<GameObject>();

    private bool isPlaying = false;


    public override bool IsInteracting
    {
        get { return isInteracting; }
        set
        {
            if (isInteracting != value)
            {
                isInteracting = value;

                if (isInteracting) StartInteraction();
                if (!isInteracting) StopInteraction();


                foreach(GameObject go in silhouettes)
                {
                    go.SetActive(isInteracting);
                }
            }
        }
    }


    public override void StartInteraction()
    {
        StopAllCoroutines();
        if (isPlaying)
        {
            StartCoroutine(FillSprites(secondaryDelay));
        }
        else
        {
            StartCoroutine(FillSprites(delayTime));
        }

        //GameManager.Retrieve<FillSprites>().Show();
    }

    protected override void Interact()
    {
        base.Interact();
        if (musicClips.Count > 0)
        {
            //pick music clip
            AudioClip clip = musicClips[Mathf.RoundToInt(Random.Range(0, musicClips.Count))];
            GameManager.Retrieve<SoundManager>().PlayMusic(clip);
        }

        //GameManager.Retrieve<FillSprites>().Hide();
    }
}
