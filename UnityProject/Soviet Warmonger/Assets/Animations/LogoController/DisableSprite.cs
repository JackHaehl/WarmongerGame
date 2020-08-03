using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSprite : MonoBehaviour
{

    [SerializeField]
    private Image logoImage;

    [SerializeField]
    private Image studioLogo;

    [SerializeField]
    private Canvas logoCanvas;

   
    [SerializeField]
    private Canvas mainMenuCanvas;

    public void Awake()
    {

        mainMenuCanvas.gameObject.SetActive(false);
    }

    private void ChangeCanvas()
    {
        logoCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);

    }
   private void destroySprite()
    {
        Destroy(logoImage);
    }

}
