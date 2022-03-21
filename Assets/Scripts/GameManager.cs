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
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    private SpawnManager spawnManager;
    public bool isGameActive = false;
    public bool isGameOver = false;
    public GameObject howToPlayButton, backButton, quitButton;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Detect when the Return key is pressed down
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return key was pressed.");
        }

        //Detect when the Return key has been released
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("Return key was released.");
        }
        if (Input.GetKeyDown(KeyCode.Return) && !isGameActive && isGameOver)
        {
            RestartGame();
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
        isGameOver = true;
}

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
