using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void closeGame()
    {
        Application.Quit();

    }

    public void loadLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
