using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void loadCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void closeGame()
    {
        Application.Quit();

    }

    public void loadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
