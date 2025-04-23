using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject creditsPanel;
    public GameObject newGameButton;
    public GameObject quitGameButton;
    public GameObject controlsButton;
    public GameObject creditsButton;
    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void TittleScreen()
    {
        SceneManager.LoadScene("Tittle Screen");
    }
    public void OpenControls()
    {
        newGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        controlsButton.SetActive(false);
        creditsButton.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        newGameButton.SetActive(true);
        quitGameButton.SetActive(true);
        controlsButton.SetActive(true);
        creditsButton.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        newGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        controlsButton.SetActive(false);
        creditsButton.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        newGameButton.SetActive(true);
        quitGameButton.SetActive(true);
        controlsButton.SetActive(true);
        creditsButton.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Cierro juego");
        Application.Quit();
    }
}
