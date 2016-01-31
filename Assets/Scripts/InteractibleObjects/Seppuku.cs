using UnityEngine;
using System.Collections;

public class Seppuku : StarableObject
{
    private const string IS_PLAYING = "IsPlaying";

    public Transform targetTransform;

    public float initialDelay = 30f;
    public Animator knifeAnimator;

    private bool canInteract = false;


    public override bool IsInteracting
    {
        get
        {
            return base.IsInteracting;
        }

        set
        {
            if(canInteract)
            {
                base.IsInteracting = value;
            }
        }
    }


    protected override void Interact()
    {
        base.Interact();
        if (knifeAnimator != null)
        {
            transform.SetParent(targetTransform);
            knifeAnimator.SetBool(IS_PLAYING, !knifeAnimator.GetBool(IS_PLAYING));
            //knifeAnimator.SetBool(IS_CLOSED, !doorAnimator.GetBool(IS_CLOSED));
        }

        GameManager.Retrieve<FillSprites>().Hide();
    }


    private IEnumerator InitialCountdown()
    {
        yield return new WaitForSeconds(initialDelay);
        canInteract = true;
        Debug.Log("Can Interact!");
    }


    private void Awake()
    {
        StartCoroutine(InitialCountdown());
    }
}
