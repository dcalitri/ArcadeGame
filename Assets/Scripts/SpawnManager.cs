using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] powerupPrefabs;
    public int powerupIndex;
    public float spawnRangeX = 5.0f;
    private GameManager gameManager;
    private float spawnStart = 1.0f;
    private float spawnDelay = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        if (gameManager.isGameActive)
        {
            InvokeRepeating("SpawnPowerUps", spawnStart, spawnDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerUps()
    {
        Instantiate(powerupPrefabs[powerupIndex], new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 5), powerupPrefabs[powerupIndex].transform.rotation);
    }
}
