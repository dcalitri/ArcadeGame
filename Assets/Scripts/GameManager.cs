using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    private Button button;


    // Start is called before the first frame update
    void Start()
    // Hides the mouse cursor upon hitting the start button
    {
     Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
