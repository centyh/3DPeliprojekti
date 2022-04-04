using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongwomenAnimations : MonoBehaviour
{
    Animator anim;

    private Vector2 moveVector;

    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("WalkForward");

            //anim.SetBool("WalkForward", true);
            //anim.SetBool("WalkLeft", false);
            //anim.SetBool("WalkRight", false);
            //anim.SetBool("Idle", false);
        }


        if (Input.GetKey(KeyCode.A))
        {
            anim.SetTrigger("WalkLeft");

            //anim.SetBool("WalkLeft", true);
            //anim.SetBool("WalkRight", false);
            //anim.SetBool("WalkForward", false);
            //anim.SetBool("Idle", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetTrigger("WalkRight");

            //anim.SetBool("WalkRight", true);
            //anim.SetBool("WalkLeft", false);
            //anim.SetBool("WalkForward", false);
            //anim.SetBool("Idle", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");

            //anim.SetBool("WalkForward", false);
            //anim.SetBool("WalkLeft", false);
            //anim.SetBool("WalkRight", false);
            //anim.SetBool("Idle", false);
        }
        if(Input.anyKey == false)
        {
            anim.SetTrigger("Idle");

        }

        

    }
}
