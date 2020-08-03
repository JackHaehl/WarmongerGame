using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForCanvas : MonoBehaviour
{
    [SerializeField]
    private Canvas logoCanvas;

    [SerializeField]
    private Animator logoAnim;

    private void Awake()
    {
        
    }

    private void Update()
    {
        checkForCanvas();
    }

    private void checkForCanvas()
    {
        if(logoCanvas.gameObject.activeInHierarchy == true)
        {
            logoAnim.SetBool("Active", false);
        }
        if(logoCanvas.gameObject.activeInHierarchy == false)
        {
            logoAnim.SetBool("Active", true);
        }

    }

}
