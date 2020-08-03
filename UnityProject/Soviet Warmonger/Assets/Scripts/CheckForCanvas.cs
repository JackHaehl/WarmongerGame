using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForCanvas : MonoBehaviour
{
    [SerializeField]
    [Tooltip ("Canvas Containing the Logo Game Objects")]
    private Canvas logoCanvas;

    [SerializeField]
    [Tooltip ("Animator for the Logo Game Object")]
    private Animator logoAnim;
    
    [SerializeField]
    [Tooltip ("Animator for the ButtonGroup Game Object")]
    private Animator buttonAnim;

    private void Update()
    {
        checkForCanvas();
    }

    //Method that checks to see if the canvas for the Different menu objects is active or not.
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

    //Method that activates the animation for the button group.
    private void buttonInFrame()
    {
        buttonAnim.SetTrigger("LogoIsStill");
    }

}
