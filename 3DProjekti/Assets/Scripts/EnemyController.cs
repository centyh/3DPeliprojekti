using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    protected NavMeshAgent enemyMesh;

    public float damage;

    public static float health;
    public float maxHealth = 200f;


    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        playerObj = GameObject.FindGameObjectWithTag("Player");

        health = maxHealth;     
    }


    void Update()
    {
        enemyMesh.SetDestination(playerObj.transform.position);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthBar.health -= damage;
            Debug.Log("Pelaajaan osui");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= Ammo.damage;
            Debug.Log("Viholliseen osui: " + Ammo.damage);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
            GameManager.currentScore += 50;
        }
    }
}
