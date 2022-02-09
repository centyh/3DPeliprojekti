using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            Debug.Log("Juokset tällä hetkellä");
        }
    }
}

