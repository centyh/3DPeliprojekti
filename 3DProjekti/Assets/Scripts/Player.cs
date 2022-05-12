using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    Rigidbody rb;


    public static bool isAlive = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }


    void FixedUpdate()
    {

        //Jos pelaaja on hengiss�, voidaan liikkua jokaiseen suuntaan k�ytt�m�ll� WASD-n�pp�imi�
        if (isAlive && !UIManager.gameIsPaused)
        {
            float xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float zMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Translate(xMovement, 0, zMovement);

            //Jos liikutaan ja pidet��n Shift-n�pp�in painettuna, pelaaja "juoksee"
            if (Input.GetKey(KeyCode.LeftShift))
            {
                float xRunMovement = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
                float zRunMovement = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
                transform.Translate(xRunMovement, 0, zRunMovement);

            }
        }
        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else
        {
            //Jos pelaaja ei ole hengiss�, asetetaan liike 0
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


   
}

