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
        //Jos pelaaja on hengiss‰, voidaan liikkua jokaiseen suuntaan k‰ytt‰m‰ll‰ WASD-n‰pp‰imi‰
        if (isAlive)
        {
            float xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float yMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Translate(xMovement, 0, yMovement);

            //Jos liikutaan ja pidet‰‰n Shift-n‰pp‰in painettuna, pelaaja "juoksee"
            if (Input.GetKey(KeyCode.LeftShift))
            {
                float xRunMovement = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
                float yRunMovement = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
                transform.Translate(xRunMovement, 0, yRunMovement);
                Debug.Log("Juokset t‰ll‰ hetkell‰");
            }
        }
        else
        {
            //Jos pelaaja ei ole hengiss‰, asetetaan liike 0
            rb.velocity = Vector3.zero;
        }

        //HealthBar.health = 100;
        //Debug.Log(isAlive);

        if(HealthBar.health <= 0)
        {
            PlayerDeath();
        }
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HealthItem"))
        {
            HealthBar.health += 20;
            Debug.Log("Sait 20 el‰m‰pistett‰ lis‰‰");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("AmmoItem"))
        {
            Debug.Log("Sait lis‰‰ ammuksia");
            Destroy(collision.gameObject);
        }
    }



    void PlayerDeath()
    {
        rb.velocity = Vector3.zero;
        isAlive = false;

        //if (HealthBar.health <= 0)
        //{
            

        //}
    }


   
}

