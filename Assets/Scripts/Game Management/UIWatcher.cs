using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UIWatcher : MonoBehaviour
{
    private const int INTERACTIVE_UI_LAYER_ID = 9;

    private EventSystem CachedEventSystem
    {
        get { return (GameManager.Retrieve<EventSystem>()); }
    }

    public List<RaycastResult> RaycastCenterScreen(PointerEventData pointerData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        if(CachedEventSystem.IsPointerOverGameObject()) Debug.Log("we are over stuff?");
        pointerData.position = Input.mousePosition;//new Vector2(Screen.width / 2, Screen.height / 2);

        CachedEventSystem.RaycastAll(pointerData, results);

        Debug.Log(results.Count);

        return results;
    }


    private void Update()
    {
        foreach (RaycastResult result in RaycastCenterScreen(new PointerEventData(CachedEventSystem)))
        {
            if(result.gameObject.layer == INTERACTIVE_UI_LAYER_ID)
            {
                //we found and interactive object, now we need to stare at it to activate,
                //then drag it around??
                Debug.Log("holy fuck this worked : " + result.gameObject.name);
            }
        }
    }
}
