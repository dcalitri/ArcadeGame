using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject howToPlayMenu;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    private SpawnManager spawnManager;
    public bool isGameActive = false;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        //Hides the Mouse Cursor on Hitting Start Button
        Cursor.visible = false;

        // How to Quit back to the Arcade Machine main menu
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnManager.SpawnPowerUp();
        spawnManager.SpawnPowerUp2();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.Select();
        isGameOver = true;
}

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
