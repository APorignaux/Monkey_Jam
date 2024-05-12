using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //charge le niveau 1
    }

    public void QuitGame()
    {
        Application.Quit();//quitte le jeu//
    }

    public void BackToMainMenu()
    {

    }
}
