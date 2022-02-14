using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeed;

    public bool isAlive = true;

    void Start()
    {
        


    }


    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(xMovement, 0, yMovement);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            float xRunMovement = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
            float yRunMovement = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
            transform.Translate(xRunMovement, 0, yRunMovement);
            Debug.Log("Juokset t‰ll‰ hetkell‰");
        }

        Death();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthItem"))
        {
            HealthBar.health += 20;
            Debug.Log("Sait 20 el‰m‰pistett‰ lis‰‰");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("AmmoItem"))
        {
            Debug.Log("Sait lis‰‰ ammuksia");
            Destroy(other.gameObject);
        }
    }

    void Death()
    {
        if(HealthBar.health <= 0)
        {
            isAlive = false;

        }
    }
}

