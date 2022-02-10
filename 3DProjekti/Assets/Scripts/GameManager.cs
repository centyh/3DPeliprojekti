using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject level1;

    void Start()
    {
        //StartCoroutine(level1Screen());
    }


    void Update()
    {
        
    }

    //IEnumerator level1Screen()
    //{
    //    level1.SetActive(true);
    //    yield return new WaitForSeconds(4);
    //    level1.SetActive(false);
    //}
}
