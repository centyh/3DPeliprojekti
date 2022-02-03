using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed;
    public Transform target, player;
    float mouseX, mouseY;
    
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
