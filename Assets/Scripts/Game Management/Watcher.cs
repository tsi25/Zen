using UnityEngine;
using System.Collections;

public class Watcher : MonoBehaviour
{
    private const int INTERACTIVE_LAYER_ID = 8;

    public GameObject rotationController;

    private InteractibleObject currentInteractibleObject = null;

    public InteractibleObject CurrentInteractibleObject
    {
        get { return currentInteractibleObject; }
        set
        {
            if (currentInteractibleObject == value) return;

            if (value == null)
            {
                currentInteractibleObject.IsInteracting = false;
                currentInteractibleObject = null;
            }
            else
            {
                currentInteractibleObject = value;
                currentInteractibleObject.IsInteracting = true;
            }
        }
    }


    public void Update()
    {
        transform.rotation = rotationController.transform.rotation;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity);

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
