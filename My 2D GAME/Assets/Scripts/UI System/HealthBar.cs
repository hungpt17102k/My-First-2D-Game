using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private Text healthText;
    private int maxHealth;

    private void Start()
    {
        healthText = gameObject.GetComponentInChildren<Text>();
        maxHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavoir>().maxHealth;
        healthText.text = $"{maxHealth}/{maxHealth}";
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        healthText.text = $"{health}/{maxHealth}";
    }

}
