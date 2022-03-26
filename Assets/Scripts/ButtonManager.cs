using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject howToPlayMenu;
    public GameObject gameOverScreen;
    public Button howToPlayButton;
    public Button startButton;
    public Button backButton;
    public Button restartButton;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    // Start is called before the first frame update
    public void HowToPlayButtonPressed()
    {
        howToPlayMenu.SetActive(true);
        backButton.Select();
        titleScreen.SetActive(false);
    }

    public void BackButtonPressed()
    {
        titleScreen.SetActive(true);
        startButton.Select();
        howToPlayMenu.SetActive(false);
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
