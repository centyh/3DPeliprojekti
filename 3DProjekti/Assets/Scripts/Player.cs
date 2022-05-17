using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    public float yPosition = 0f;

    Rigidbody rb;
    private UIManager uiM;


    public static bool isAlive = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiM = FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }


    void FixedUpdate()
    {

        //Jos pelaaja on hengissä, voidaan liikkua jokaiseen suuntaan käyttämällä WASD-näppäimiä
        if (isAlive && !UIManager.gameIsPaused)
        {
            float xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float zMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Translate(xMovement, 0, zMovement);

            //Jos liikutaan ja pidetään Shift-näppäin painettuna, pelaaja "juoksee"
            if (Input.GetKey(KeyCode.LeftShift))
            {
                float xRunMovement = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
                float zRunMovement = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
                transform.Translate(xRunMovement, 0, zRunMovement);

            }
        }
        if(transform.position.y > 0)
        {
            //transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        }
        else
        {
            //Jos pelaaja ei ole hengissä, asetetaan liike 0
            rb.velocity = Vector3.zero;
        }

        //HealthBar.health = 100;
        //Debug.Log(isAlive);

        if(HealthBar.health <= 0)
        {
            PlayerDeath();
        }
        
    }


    void PlayerDeath()
    {
        rb.velocity = Vector3.zero;
        isAlive = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthItem"))
        {
            HealthBar.health += 20;
            Debug.Log("Sait 20 elämäpistettä lisää" + HealthBar.health);
        }
        if (other.gameObject.CompareTag("AmmoItem"))
        {
            uiM.money += 30;
            Debug.Log("Sait lisää RAHAA" + uiM.money);
        }
    }

}

