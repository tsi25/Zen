using UnityEngine;
using System.Collections;

public class InteractibleObject : MonoBehaviour
{
    public float waitTime = 1f;
    public GameObject silhouette;

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

                if(silhouette != null) silhouette.SetActive(isInteracting);
            }
        }
    }
    

    public virtual void StartInteraction()
    {
        
    }


    public virtual void StopInteraction()
    {
        
    }


    protected virtual void Interact()
    {

    }
}
