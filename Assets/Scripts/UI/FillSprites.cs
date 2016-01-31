using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FillSprites : MonoBehaviour
{
    public GameObject root;
    public Image[] fillImages = new Image[0];
    private float fillAmount = 0f;

    public float FillAmount
    {
        get { return fillAmount; }
        set
        {
            fillAmount = value;

            foreach(Image image in fillImages)
            {
                image.fillAmount = value;
            }

            if(value > 0 && value < 1)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }


    public void Show()
    {
        root.SetActive(true);
    }


    public void Hide()
    {
        root.SetActive(true);
    }
}
