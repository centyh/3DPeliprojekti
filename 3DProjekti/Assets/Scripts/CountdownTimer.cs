using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public float currentTime = 0f;
    public float startingTime = 30f;

    void Start()
    {
        currentTime = startingTime;
    }


    void Update()
    {
        
    }
}
