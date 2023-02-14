using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>(); 
        rb.velocity = Vector2.zero;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        TurnToPlayer(enemy);
        if (enemy.enemyAttackSpeed <= enemy.timeSinceLastAttack)
        {
            Attack(enemy, enemy.target);
            enemy.timeSinceLastAttack = 0;
        }
        
    }
    public override void FixedUpdate(EnemyStateManager enemy)
    {
        
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {

    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Fence")
        {
            enemy.SwitchState(enemy.MoveState);
        }
    }
    private void TurnToPlayer(EnemyStateManager enemy)
    {
        if (enemy.currentCollision == null) return;
        if (enemy.transform.position.x > enemy.currentCollision.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (enemy.transform.position.x < enemy.currentCollision.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void Attack(EnemyStateManager enemy, GameObject target)
    {
        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Attack");

        float damage = enemy.enemyStats.GetDamage();

        if (target.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerHealth>().PlayerGetDamage(damage);
        }
        else if (target.gameObject.tag == "Fence")
        {
            target.GetComponent<Fence>().FenceGetDamage(damage);
        }
    }
}
