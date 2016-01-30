using UnityEngine;
using System.Collections;

public class Watcher : MonoBehaviour
{
    private const int INTERACTIVE_LAYER_ID = 8;

    private InteractibleObject currentInteractibleObject = null;

    public InteractibleObject CurrentInteractibleObject
    {
        get { return currentInteractibleObject; }
        set
        {
            if(currentInteractibleObject != value)
            {
                //if there is a current interactible, and we are changing it, then stop it.
                if (currentInteractibleObject != null)  currentInteractibleObject.IsInteracting = false;

                //set the value, and start the new one, if there is a new one
                currentInteractibleObject = value;
                if (currentInteractibleObject != null)  currentInteractibleObject.IsInteracting = true;
            }
        }
    }


    public void Update()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.forward, Mathf.Infinity);

        //run through all the hits
        for(int i = 0; i < hits.Length; i++)
        {
            //is thehit in  interactive layer
            if(hits[i].collider.gameObject.layer == INTERACTIVE_LAYER_ID)
            {
                InteractibleObject io = hits[i].collider.gameObject.GetComponent<InteractibleObject>();
                //does the hit actually have an interactible object?
                if (io != null)
                {
                    //we found a new object!
                    CurrentInteractibleObject = io;
                    return;
                }
            }
        }

        CurrentInteractibleObject = null;
    }
}
