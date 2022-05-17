using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public AudioSource laughSound;

    public GameObject pauseMenu;
    public GameObject shopView;

    public GameObject GameOver;

    public static bool gameIsPaused = false;
    public bool shopViewOpen = false;

    public EnemySpawner enemySpawner;
    public GameManager gameManager;
    public HealthBar hb;

    public float dmgButtonPrice;
    public float healthButtonPrice;
    public float dontBuyPrice;
    public float currentScore;
    public float money;

    private int dmgBought = 0;
    private int healthBought = 0;
    private int hahaBought = 0;

    private float timer;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dmgButtonPriceText;
    public TextMeshProUGUI currentDmgText;
    public TextMeshProUGUI healthButtonPriceText;
    public TextMeshProUGUI currentHealthText;
    public TextMeshProUGUI dontBuyMePriceText;
    public TextMeshProUGUI dontBuyText;

    void Start()
    {
        currentScore = 0f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        hb = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();


        pauseMenu.SetActive(false);

    }


    void Update()
    {
        PlayerPrefs.SetFloat("Highscore", currentScore);

        currentDmgText.text = "Damage: " + Ammo.damage;
        currentHealthText.text = "Max Health: " + hb.maxHealth;

        dmgButtonPriceText.text = "Cost: " + dmgButtonPrice;
        healthButtonPriceText.text = "Cost: " + healthButtonPrice;

        dontBuyText.text = "Don't Buy Me";
        dontBuyMePriceText.text = "Cost: " + dontBuyPrice;
        
        moneyText.text = "MONEY: " + money;
        scoreText.text = "SCORE: " + currentScore;

        if(dmgBought == 5)
        {
            dmgButtonPriceText.text = "Out of stock!";
        }
        if(healthBought == 5)
        {
            healthButtonPriceText.text = "Out of stock!";
        }
        if(hahaBought == 1)
        {
            dontBuyText.text = "We told you not to buy";
            dontBuyMePriceText.text = "Hahaha!";
        }

        PauseGame();
        ShopView();

        if (!Player.isAlive && HealthBar.health <= 0)
        {
            GameOver.SetActive(true);
            Invoke("YouDied", 10f);
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
                gameIsPaused = false;
            }
            else
            {
                shopView.SetActive(true);
                shopViewOpen = true;
                Cursor.visible = true;  
                Cursor.lockState = CursorLockMode.Confined;
                gameIsPaused = true;
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


    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void MoreDamage()
    {
        if(money >= dmgButtonPrice && dmgBought < 5)
        {
            dmgBought++;
            Ammo.damage += 10;
            money -= dmgButtonPrice;
            dmgButtonPrice += dmgBought * 100f;
        }
    }

    public void MoreHealth()
    {
        if(money >= healthButtonPrice && healthBought < 5)
        {
            healthBought++;
            hb.maxHealth += 10;
            money -= healthButtonPrice;
            healthButtonPrice += healthBought * 50f;
            Debug.Log("Current Health: " + hb.maxHealth);
        }
    }

    public void DontBuy()
    {
        if(money >= dontBuyPrice && hahaBought < 1)
        {
            hahaBought++;
            money -= dontBuyPrice;
            laughSound.Play();
        }
    }

    public void YouDied()
    {
        SceneManager.LoadScene("Highscore");
        
    }
}
