using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEffect : MonoBehaviour
{
    public ParticleSystem pickupEffect = null;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickupEffect.Play();
            Debug.Log("HEP HEP HEP HEP HEP HEP");
        }
        else
        {
            pickupEffect.Stop();
        }
    }
}
