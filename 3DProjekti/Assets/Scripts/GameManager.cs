using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject level1;
    public TextMeshProUGUI scoreText;

    public static float currentScore;

    void Start()
    {
        currentScore = 0f;
        
        //StartCoroutine(level1Screen());
    }


    void Update()
    {
        scoreText.text = "Score: " + currentScore;
    }

    //IEnumerator level1Screen()
    //{
    //    level1.SetActive(true);
    //    yield return new WaitForSeconds(4);
    //    level1.SetActive(false);
    //}
}
