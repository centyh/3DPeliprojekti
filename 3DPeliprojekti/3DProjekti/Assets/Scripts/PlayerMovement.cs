using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(xMovement, 0, yMovement);

    }
}
