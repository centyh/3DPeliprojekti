using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEffect : MonoBehaviour
{
    public ParticleSystem pickupEffect = null;
    public AudioSource pickupSound;


    private void Start()
    {
        pickupSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickupSound.Play();
            StartCoroutine(PickUpEffect());
            Destroy(gameObject, 0.4f);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            pickupSound.Play();
            StartCoroutine(PickUpEffect());
            Destroy(gameObject, 0.4f);
        }
    }

    IEnumerator PickUpEffect()
    {
        pickupEffect.Play();
        yield return new WaitForSeconds(1f);
        pickupEffect.Stop();
    }
}
