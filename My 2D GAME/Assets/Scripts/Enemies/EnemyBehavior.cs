using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //bien cho mau 
    public int maxHealth = 15;
    int currentHealth;

    //bien cho di chuyen
    public float speed;
    private float dazedTime;
    public float startDezedTime;
    private float speedRemain;

    private Transform target;
    private SpriteRenderer rend;
    public Animator ani;

    // Bien lay ten cua gameObject;
    private string enemyName;

    private string getHit = "GetHit_Trigger";
    private string dead = "isDie";

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rend = GetComponent<SpriteRenderer>();
        enemyName = gameObject.name;
        speedRemain = gameObject.GetComponent<EnemyBehavior>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        //khi bi tan cong se dung lai
        if(dazedTime <= 0)
        {
            speed = speedRemain;
        } else
        {
            speed = 0f;
            dazedTime -= Time.deltaTime;
        }

        if (enemyName.Contains("Slime"))
        {
            gameObject.GetComponent<SlimeMovement>().SlimeMove(speed);
        } 
        else if (enemyName.Contains("Eye Ball"))
        {
            gameObject.GetComponent<EyeBallMovement>().EyeBallMove(speed);
        }

        Flip();
    }

    // flip the enemies to direct the target
    private void Flip()
    {
        if(target.position.x < transform.position.x)
        {
            rend.flipX = true;
        } else
        {
            rend.flipX = false;
        }
    }

    public void TakeDamge(int damge)
    {
        dazedTime = startDezedTime; //bi dung lai khi tan cong

        currentHealth -= damge; //mat mau

        //play get attack animation
        ani.SetTrigger(getHit);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Slime is death");

        //Die animation
        ani.SetBool(dead, true);

        //Destroy 
        Destroy(gameObject, 3f);

        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
