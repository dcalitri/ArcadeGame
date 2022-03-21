using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] powerupPrefabs;
    public int powerupIndex;
    public float spawnRangeX = 5.0f;


    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPowerUp()
    {
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex], new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 5), powerupPrefabs[powerupIndex].transform.rotation);
    }
}
