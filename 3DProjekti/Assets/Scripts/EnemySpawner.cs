using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    public enum SpawnState { SPAWNING, WAITING, COUNTING };   

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves completed");
        }
        else
        {
            nextWave++;
        }

        
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log("Spawning Wave: " + wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Debug.Log("Spawning enemy: " + enemy.name);
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, Quaternion.identity);
    }

}
