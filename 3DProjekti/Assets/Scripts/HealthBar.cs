using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    public static float health;  

    void Start()
    {
        
        healthBar = GetComponent<Image>();
        health = maxHealth;
        Debug.Log(health);
    }


    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        currentHealth = health;
    }

    
}
