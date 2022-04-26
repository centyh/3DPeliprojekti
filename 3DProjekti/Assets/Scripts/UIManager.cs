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

    public GameObject GameOver;

    public static bool gameIsPaused = false;
    public bool shopViewOpen = false;

    public EnemySpawner enemySpawner;
    public GameManager gameManager;

    public Button dmgButton;
    public float dmgButtonPrice;
    
    public float currentScore;
    public float money;

    private float timer;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
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
        dmgButtonPriceText.text = "Price: " + dmgButtonPrice;
        moneyText.text = "MONEY: " + money;

        PauseGame();
        ShopView();

        if (!Player.isAlive && HealthBar.health <= 0)
        {
            GameOver.SetActive(true);
            Invoke("YouDied", 10f);
        }

        timer += Time.deltaTime;
        
        if(timer > 1f)
        {
            currentScore += 1;
            scoreText.text = "SCORE: " + currentScore;
            timer = 0;
        }
    }

    public void ShopView()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (shopViewOpen)
            {
                shopView.SetActive(false);
                shopViewOpen = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;   
            }
            else
            {
                shopView.SetActive(true);
                shopViewOpen = true;
                Cursor.visible = true;  
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        //    if (enemySpawner.waveCountdown != 0 && enemySpawner.nextWave >= 1 && !gameIsPaused)
        //{
        //    if(Input.GetKeyDown(KeyCode.Tab))
        //    shopView.SetActive(true);
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.Confined;
        //}
        //if(enemySpawner.waveCountdown <= 0)
        //{
        //    shopView.SetActive(false);
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }           
        }     
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    //public void ContinueGame()
    //{
    //    pauseMenu.SetActive(false);
    //    Time.timeScale = 1;
    //    gameIsPaused = false;
    //    Debug.Log("Continue Game");
    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void MoreDamage()
    {
        if(money >= dmgButtonPrice)
        {
            Ammo.damage += 20;
            currentScore -= dmgButtonPrice;
            dmgButtonPrice += dmgButtonPrice * 0.3f;
        }
    }

    public void YouDied()
    {
        SceneManager.LoadScene("Highscore");
        
    }
}
