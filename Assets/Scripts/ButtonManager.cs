using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject controlPanel;
    public GameObject gameOverScreen;
    public Button howToPlayButton;
    public Button startButton;
    public Button backButton;
    public Button restartButton;
    


    // Start is called before the first frame update
    public void HowToPlayButtonPressed()
    {
        controlPanel.SetActive(true);
        backButton.Select();
        titleScreen.SetActive(false);
    }

    public void BackButtonPressed()
    {
        titleScreen.SetActive(true);
        startButton.Select();
        controlPanel.SetActive(false);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void RestartButtonPressed()
    {
        titleScreen.SetActive(true);
        startButton.Select();
        gameOverScreen.SetActive(false);
    }
}
