using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int timeToSpawn;
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    float spawnTime = 10f;
    float curSpawnTime;

    private void Start()
    {
        curSpawnTime = spawnTime;
    }

    void Update()
    {
        SpawnObjects();

    }

    public void SpawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();


        float posX, posZ;
        Vector3 pos;

        curSpawnTime -= Time.deltaTime;

        if (curSpawnTime <= 0)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            posX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            posZ = Random.Range(c.bounds.min.z, c.bounds.max.z);
            pos = new Vector3(posX, 1, posZ);

            Destroy(Instantiate(toSpawn, pos, toSpawn.transform.rotation), 10f);

            curSpawnTime = spawnTime;

            Debug.Log("Spawnattu: " + spawnPool[randomItem]);

        }
    }

    
}
