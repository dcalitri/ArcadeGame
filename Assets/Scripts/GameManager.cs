using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    private SpawnManager spawnManager;
    public bool isGameActive = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

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
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
