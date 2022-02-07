using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;

    private int randPosition;

    void Start()
    { 

        for(int i = 0; i < enemyPrefab.Length; i++)
        {
            randPosition = Random.Range(0, spawnPoints.Length);
            enemyPrefab[i] = Instantiate(enemyPrefab[i], spawnPoints[randPosition].position, Quaternion.identity);
        }

    }


    void Update()
    {
        
    }
}
