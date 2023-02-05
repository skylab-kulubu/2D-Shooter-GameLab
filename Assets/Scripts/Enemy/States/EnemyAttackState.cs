using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Attack");                                                  

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>(); 
        rb.velocity = Vector2.zero;                         


    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if(enemy.enemyAttackSpeed <= enemy.timeSinceLastAttack)
        {
            Attack(enemy);
            enemy.timeSinceLastAttack = 0;
        }
        
    }
    public override void FixedUpdate(EnemyStateManager enemy)
    {
        
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
        
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {

    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.SwitchState(enemy.MoveState);
        }
    }

    public void Attack(EnemyStateManager enemy)
    {
        float damage = enemy.enemyStats.GetDamage();
        enemy.currentCollision.transform.GetComponent<PlayerHealth>().PlayerGetDamage(damage);
    }
}
