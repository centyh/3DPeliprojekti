using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private float maxHealth = 100f;
    public float currentHealth;
    public static float health;  

    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }


    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        currentHealth = health;
    }

    
}
