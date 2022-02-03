using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform playerObj;
    protected NavMeshAgent enemyMesh;

    public float damage = 25f;


    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        enemyMesh.SetDestination(playerObj.position);
    }



    
}
