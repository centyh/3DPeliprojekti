using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    public UIManager uiManager;

    public enum SpawnState { SPAWNING, WAITING, COUNTING };   

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform enemy2;
        public Transform enemy3;
        public int count;
        public int count2;
        public int count3;
        public float rate;
    }

    public TextMeshProUGUI countdownText;

    public float currentTime = 0f;


    public int nextWave = 0;

    public float timeBetweenWaves = 10f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();

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
            countdownText.text = "Next level starts: " + waveCountdown.ToString("0");

            if(waveCountdown <= 0)
            {
                countdownText.enabled = false;
            }
            else
            {
                countdownText.enabled = true;
            }
        }

        
    }


    void WaveCompleted()
    {
        Debug.Log("Wave completed");
        uiManager.currentScore += 50;

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
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

        for (int i = 0; i < wave.count2; i++)
        {
            SpawnEnemy2(wave.enemy2);

            yield return new WaitForSeconds(1f / wave.rate);
        }

        for (int i = 0; i < wave.count3; i++)
        {
            SpawnEnemy3(wave.enemy3);

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

    void SpawnEnemy2(Transform enemy2)
    {
        Debug.Log("Spawning enemy: " + enemy2.name);
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy2, sp.position, Quaternion.identity);
    }

    void SpawnEnemy3(Transform enemy3)
    {
        Debug.Log("Spawning enemy: " + enemy3.name);
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy3, sp.position, Quaternion.identity);
    }
}
