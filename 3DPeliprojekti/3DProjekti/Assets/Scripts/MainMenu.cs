using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SurvivalMode()
    {
        SceneManager.LoadScene("Survival");
    }
}
