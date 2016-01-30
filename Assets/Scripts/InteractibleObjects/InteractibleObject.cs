using UnityEngine;
using System.Collections;

public class InteractibleObject : MonoBehaviour
{
    public float waitTime = 1f;

    private bool isInteracting = false;
    
    public bool IsInteracting
    {
        get { return isInteracting; }
        set
        {
            if(isInteracting != value)
            {
                isInteracting = value;

                if (isInteracting) StartInteraction();
                if (!isInteracting) StopInteraction();
            }
        }
    }
    

    public virtual void StartInteraction()
    {
        StartCoroutine(InteractionDelay());
    }


    public virtual void StopInteraction()
    {
        StopAllCoroutines();
    }


    public virtual IEnumerator InteractionDelay()
    {
        yield return new WaitForSeconds(waitTime);
        Interact();
    }


    protected virtual void Interact()
    {

    }
}
