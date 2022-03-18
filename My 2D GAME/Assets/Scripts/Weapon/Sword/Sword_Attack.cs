using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Attack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamge = 5;


    //Bien set thoi gian don danh
    public float attackRate = 1f;
    float nextAttackTime = 0f;

    //Ten bien cua animation
    private string attack_Trigger = "Attack_Trigger";

    // Update is called once per frame
    void Update()
    {

        if(Time.time >= nextAttackTime)
        {
            //Then you can attack
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();

                nextAttackTime = Time.time + 1f / attackRate;
            }
            
        }
    }

    private void Attack()
    {
        //Play the attack animation
        animator.SetTrigger(attack_Trigger);

        //Detect enemies in range attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damge enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehavior>().TakeDamge(attackDamge);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
