using UnityEngine;
using System.Collections;

public class RotatableObject : InteractibleObject
{
    public enum RotationDirection
    {
        X = 0,
        Y = 1,
        Z = 2
    }

    public RotationDirection rotationDirection = RotationDirection.Y;
    public float rotationSpeed = 1f;
    private bool winding = false;

    public override void StartInteraction()
    {
        if(winding == false)
        {
            winding = true;
            StopAllCoroutines();
            StartCoroutine(WindUp());
        }
    }


    public Vector3 DesiredRotationDirection
    {
        get
        {
            Vector3 axis = Vector3.zero;
            switch(rotationDirection)
            {
                case RotationDirection.X:
                    axis = Vector3.left;
                    break;

                case RotationDirection.Y:
                    axis = Vector3.up;
                    break;

                case RotationDirection.Z:
                    axis = Vector3.forward;
                    break;
            }

            return axis;
        }
    }


    public override void StopInteraction()
    {
        StopAllCoroutines();
        winding = false;
        StartCoroutine(WindDown());
    }


    protected override void Interact()
    {
        StartCoroutine(InteractCoroutine());
    }


    private IEnumerator WindUp()
    {
        Debug.Log("winding up");
        float elapsedTime = 0f;

        while(elapsedTime < waitTime)
        {
            transform.Rotate(DesiredRotationDirection, rotationSpeed * elapsedTime/waitTime *Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Interact();
    }


    private IEnumerator InteractCoroutine()
    {
        Debug.Log("looping");
        while (IsInteracting)
        {
            transform.Rotate(DesiredRotationDirection, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }


    private IEnumerator WindDown()
    {
        Debug.Log("winding down");
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            transform.Rotate(DesiredRotationDirection, rotationSpeed * (1f - (elapsedTime / waitTime)) * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
