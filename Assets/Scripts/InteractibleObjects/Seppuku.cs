using UnityEngine;
using System.Collections;

public class Seppuku : StarableObject
{
    public float initialDelay = 30f;

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
