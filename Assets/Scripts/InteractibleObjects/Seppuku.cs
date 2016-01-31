using UnityEngine;
using System.Collections;

public class Seppuku : StarableObject
{
    private const string IS_OPEN = "IsOpen";
    private const string IS_CLOSED = "IsClosed";

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
        base.Interact();
        if (knifeAnimator != null)
        {
            //knifeAnimator.SetBool(IS_OPEN, !doorAnimator.GetBool(IS_OPEN));
            //knifeAnimator.SetBool(IS_CLOSED, !doorAnimator.GetBool(IS_CLOSED));
        }

        GameManager.Retrieve<FillSprites>().Hide();
    }


    private IEnumerator InitialCountdown()
    {
        yield return new WaitForSeconds(initialDelay);
        canInteract = true;
    }


    private void Awake()
    {
        StartCoroutine(InitialCountdown());
    }
}
