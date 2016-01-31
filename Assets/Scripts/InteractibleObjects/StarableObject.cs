using UnityEngine;
using System.Collections;

public class StarableObject : InteractibleObject
{
    public override void StartInteraction()
    {
        StopAllCoroutines();
        StartCoroutine(FillSprites(delayTime));
        GameManager.Retrieve<FillSprites>().Show();
    }


    public override void StopInteraction()
    {
        StopAllCoroutines();
        //GameManager.Retrieve<FillSprites>().Hide();
    }


    protected virtual IEnumerator FillSprites(float time)
    {
        FillSprites fillSprites = GameManager.Retrieve<FillSprites>();
        float elapsedTime = 0f;

        while(elapsedTime < time)
        {
            if (fillSprites != null) fillSprites.FillAmount = Mathf.Lerp(0f, 1f, elapsedTime/time);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Interact();
    }


    protected override void Interact()
    {
        StopInteraction();
        base.Interact();
    }
}
