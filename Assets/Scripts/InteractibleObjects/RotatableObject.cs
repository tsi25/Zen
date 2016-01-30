using UnityEngine;
using System.Collections;

public class RotatableObject : InteractibleObject
{
    public float rotationSpeed = 1f;

    public override void StartInteraction()
    {
        StopAllCoroutines();
        base.StartInteraction();
    }


    public override void StopInteraction()
    {
        StopAllCoroutines();
        StartCoroutine(StopCoroutine());
    }


    protected override void Interact()
    {
        StartCoroutine(InteractCoroutine());
    }


    public override IEnumerator InteractionDelay()
    {
        float elapsedTime = 0f;

        while(elapsedTime < waitTime)
        {
            transform.Rotate(Vector3.left, rotationSpeed * elapsedTime/waitTime *Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Interact();
    }


    private IEnumerator InteractCoroutine()
    {
        while(IsInteracting)
        {
            transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }


    private IEnumerator StopCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            transform.Rotate(Vector3.left, rotationSpeed * (1f - (elapsedTime / waitTime)) * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
