using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public GameObject introText;

    void Start()
    {
        introText.SetActive(true);
        Invoke("ChangeScene", 20f);
    }


    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Survival");
    }


}
