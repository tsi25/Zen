using UnityEngine;
using System.Collections;

public class RotatableObject : InteractibleObject
{
    public float rotationSpeed;

    public override void StartInteraction()
    {
        base.StartInteraction();
    }


    public override void StopInteraction()
    {
        base.StopInteraction();
    }


    public override IEnumerator InteractionDelay()
    {
        return base.InteractionDelay();
    }


    protected override void Interact()
    {
        base.Interact();
    }
}
