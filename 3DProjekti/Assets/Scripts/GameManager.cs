using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject level1;


    
    

    

    public EnemySpawner enemySpawner;

    void Start()
    {
        
        enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();

    }


    void Update()
    {
        

        
    }


}
