using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public UIManager uiManager;
    private Animator animator;
    private Rigidbody rb;

    [SerializeField] GameObject playerObj;
    protected NavMeshAgent enemyMesh;

    public float damage;

    public float health;
    public float maxHealth = 200f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
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
            animator.SetTrigger("Attack");
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= Ammo.damage;
            Debug.Log("Viholliseen osui: " + Ammo.damage);
            Debug.Log("Elämiä jäljellä: " + health);
        }

        if (health <= 0)
        {
            Destroy(gameObject, 3f);
            uiManager.currentScore += 50;
            animator.SetTrigger("Death");

            rb.velocity = Vector3.zero;
            enemyMesh.isStopped = true;

            bool deactiveCollider;
            deactiveCollider = GetComponent<BoxCollider>().enabled = false;
             
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
