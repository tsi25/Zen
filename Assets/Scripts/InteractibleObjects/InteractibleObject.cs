using UnityEngine;
using System.Collections;

public class InteractibleObject : MonoBehaviour
{
    public float waitTime = 1f;
    public GameObject silhouette;

    public bool delay = false;
    public float delayTime = 1f;

    protected bool isInteracting = false;
    
    public virtual bool IsInteracting
    {
        get { return isInteracting; }
        set
        {
            if(isInteracting != value)
            {
                isInteracting = value;

                if (isInteracting) StartInteraction();
                if (!isInteracting) StopInteraction();

                if(silhouette != null) silhouette.SetActive(isInteracting);
            }
        }
    }
    

    public virtual void StartInteraction()
    {
        if(delay)
        {
            StartCoroutine(Delay());
        }
        else
        {
            Interact();
        }
    }


    public virtual void StopInteraction()
    {
        
    }


    protected virtual IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        Interact();
    }


    protected virtual void Interact()
    {

    }
}
