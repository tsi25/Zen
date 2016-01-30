using UnityEngine;
using System.Collections;

public class InteractibleObject : MonoBehaviour
{
    public float waitTime = 1f;
    

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
