using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public UIManager uiManager;
    private Animator animator;
    private Rigidbody rb;

    public ParticleSystem bloodEffect = null;

    [SerializeField] GameObject playerObj;
    protected NavMeshAgent enemyMesh;

    public float damage;
    public float health;
    public float maxHealth;

    float curTime = 0f;
    float nextDamage = 0.3f;


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
        //Asetetaan Agentti jahtaamaan Pelaajaa
        enemyMesh.SetDestination(playerObj.transform.position);

        //Jos pelaaja ei ole elossa, pys‰ytet‰‰n enemy ja asetetaan Idle animaatio
        if (!Player.isAlive)
        {
            enemyMesh.velocity = Vector3.zero;
            animator.SetTrigger("Idle");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Kun bullet-objekti osuu viholliseen, v‰hennet‰‰n vihollisen health
        if (collision.gameObject.CompareTag("Bullet"))
        {

            bloodEffect.Play();
            Debug.Log("Veriefektin pit‰isi toimia nyt");
            StartCoroutine(BloodEffect());
            health -= Ammo.damage;
            Debug.Log("Viholliseen osui: " + Ammo.damage);
            Debug.Log("El‰mi‰ j‰ljell‰: " + health);
        }
        //Jos vihollisen health on 0, asetetaan vihollinen kuolleeksi ja triggerˆid‰‰n Death-animaatio
        if (health <= 0)
        {
            //uiManager.currentScore += 50;
            uiManager.money += 50;
            uiManager.currentScore += 1;
            animator.SetTrigger("Death");

            rb.velocity = Vector3.zero;
            enemyMesh.isStopped = true;

            //Poistetaan vihollisen Collider, jotta v‰ltet‰‰n tˆrm‰yksi‰, kun vihollinen on kuollut
            bool deactiveCollider;
            deactiveCollider = GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 3f);

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Jos vihollinen osuu pelaajaan, v‰hennet‰‰n pelaajan healthia 0.3sekunnin v‰lein, kunnes vihollinen ei en‰‰ osu pelaajaan
        if (collision.gameObject.CompareTag("Player"))
            
        {
            Debug.Log("Aika on: " + curTime);
            if (curTime <= 0)
            {
                //V‰hennet‰‰n pelaajan healthia
                HealthBar.health -= damage;
                animator.SetTrigger("Attack");
                Debug.Log("Osui pelaajaan");
                curTime = nextDamage;
            }
            else
            {
                curTime -= Time.deltaTime;
            }
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Kun vihollinen osuu pelaajassa olevaan sphere collideriin mik‰ on trigger, suorittaa randomisti eri hyˆkk‰ysanimaation
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            int rand = Random.Range(1, 3);

            if(rand == 1)
            {
                animator.SetTrigger("Attack");
            }
            if(rand == 2)
            {
                animator.SetTrigger("Attack2");
            }
        }
    }


    IEnumerator BloodEffect()
    {

        yield return new WaitForSeconds(0.5f);
        bloodEffect.Stop();
    }
}
