using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavoir : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public HealthBar healthBar;
    public Animator ani;
    public GameObject holdWeapon;

    // Var for the parameter of transmation in animation
    private string getHit = "GetHit_Trigger";
    private string die = "isDie";

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void HealHP(int health)
    {
        currentHealth += health;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }

    void TakeDamage(int damage)
    {
        // Play get hit animation
        ani.SetTrigger(getHit);

        if(damage > currentHealth)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }

        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        // Play death animation
        ani.SetBool(die, true);

        //Disable this component
        holdWeapon.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet")) 
        {
            TakeDamage(2);
        }
    }
}
