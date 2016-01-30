using UnityEngine;
using System.Collections;

[System.Serializable]
public class LightParamaters : System.Object
{
    public Color lightcolor = Color.white;
    public float intensity = 1f;
    public float range = 1f;
}

public class LightObject : InteractibleObject
{
    public Light controlledLight;
    public float transitionTime = 1f;

    public LightParamaters inactiveLight;
    public LightParamaters activeLight;


    public override void StartInteraction()
    {
        StopAllCoroutines();
        StartCoroutine(TransitionLight(activeLight));
    }


    public override void StopInteraction()
    {
        StopAllCoroutines();
        StartCoroutine(TransitionLight(inactiveLight));
    }


    private IEnumerator TransitionLight(LightParamaters to)
    {
        float elapsedTime = 0f;

        while(elapsedTime < transitionTime)
        {
            controlledLight.intensity = Mathf.Lerp(controlledLight.intensity, to.intensity, elapsedTime / transitionTime);
            controlledLight.range = Mathf.Lerp(controlledLight.range, to.range, elapsedTime / transitionTime);
            controlledLight.color = Color.Lerp(controlledLight.color, to.lightcolor, elapsedTime / transitionTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        controlledLight.intensity = to.intensity;
        controlledLight.range = to.range;
        controlledLight.color = to.lightcolor;
    }
}
