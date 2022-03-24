using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject shopView;

    public static bool isPaused = false;

    public EnemySpawner enemySpawner;
    public GameManager gameManager;

    public Button dmgButton;
    public int dmgButtonPrice;
    
    public float currentScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI dmgButtonPriceText;
    public TextMeshProUGUI currentDmgText;

    void Start()
    {
        currentScore = 0f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        pauseMenu.SetActive(false);

    }


    void Update()
    {
        currentDmgText.text = "Damage: " + Ammo.damage;

        scoreText.text = "Score: " + currentScore;
        dmgButtonPriceText.text = "Price: " + dmgButtonPrice;


        PauseGame();
        ShopView();
        
    }

    public void ShopView()
    {
        if (enemySpawner.waveCountdown != 0 && enemySpawner.nextWave >= 1)
        {
            shopView.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(enemySpawner.waveCountdown <= 0)
        {
            shopView.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
                
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }           
        }     
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Continue Game");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void MoreDamage()
    {
        if(currentScore >= dmgButtonPrice)
        {
            Ammo.damage += 10;
            currentScore -= dmgButtonPrice;
        }
    }
}
