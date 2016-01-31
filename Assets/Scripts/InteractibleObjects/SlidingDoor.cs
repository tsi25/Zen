using UnityEngine;
using System.Collections;

public class SlidingDoor : StarableObject
{
    public Animator doorAnimator;
    public float secondaryDelay = 1f;
    public AudioClip slidingDoorClip;

    private const string IS_OPEN = "IsOpen";
    private const string IS_CLOSED = "IsClosed";


    public override void StartInteraction()
    {
        StopAllCoroutines();
        if(doorAnimator.GetBool(IS_OPEN))
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
        if (doorAnimator != null)
        {
            if (slidingDoorClip != null) GameManager.Retrieve<SoundManager>().Play(slidingDoorClip);
            doorAnimator.SetBool(IS_OPEN, !doorAnimator.GetBool(IS_OPEN));
            doorAnimator.SetBool(IS_CLOSED, !doorAnimator.GetBool(IS_CLOSED));
        }

        //GameManager.Retrieve<FillSprites>().Hide();
    }
}
