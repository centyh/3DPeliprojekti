using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianAnimations1 : MonoBehaviour
{
    Animator anim;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;

    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    float nextAnimEvent = 0f;
    float animDelay = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();

    }



    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        //Increase velocity in Z direction
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        //Decrease velocity in Z direction
        if (backPressed && velocityZ > -currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }
        //Decrease velocity in X direction
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        //Increase velocity in X direction
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        //if (!forwardPressed && velocityZ < 0.0f)
        //{
        //    velocityZ = 0.0f;
        //}

        //Increase velocity if left is not pressed and velocityX < 0
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        //Decrease velocity if right is not pressed and velocityX > 0 
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.5f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }
        if (!forwardPressed && !backPressed && velocityZ != 0.0f && (velocityZ > -0.5f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
        }

        //----------------------------------------------------------
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if(forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if(velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if(forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        //----------------------------------------------------------
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if(leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if(velocityX < - currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if(leftPressed && velocityX > - currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }

        //----------------------------------------------------------
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        else if(rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX = Time.deltaTime * deceleration;
            if(velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if(rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }

        //----------------------------------------------------------
        if (backPressed && runPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ = -currentMaxVelocity;
        }
        else if (backPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
            if (velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (backPressed && velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }


        anim.SetFloat("Velocity Z", velocityZ);
        anim.SetFloat("Velocity X", velocityX);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time >= nextAnimEvent)
            {
                nextAnimEvent = Time.time + animDelay;
                StartCoroutine(Attack());
            }
            
        }

        if (HealthBar.health <= 0)
        {
            anim.SetTrigger("Death");
        }

    }

    public void Death()
    {
        

    }

    IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.8f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
    }
}
