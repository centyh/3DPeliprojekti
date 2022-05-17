using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nameText;
    public string playerName;
    public InputField inputField;

    void Start()
    {
        PlayerPrefs.GetFloat("Highscore");
    }


    void Awake()
    {
        float score = PlayerPrefs.GetFloat("Highscore");
        scoreText.text = "" + score;

    }

    public void SetPlayerName()
    {
        PlayerPrefs.SetString("Name", playerName);
    }


}
