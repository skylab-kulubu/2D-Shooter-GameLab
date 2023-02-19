using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacksPlayerState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.enemyAttacksPlayer = true;
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>(); 
        rb.velocity = Vector2.zero;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        Attack(enemy, enemy.target);

        //StartAttackAction(enemy, enemy.target);


    }

    //private void StartAttackAction(EnemyStateManager enemy, GameObject target)
    //{
    //    if (enemy.enemyAttackSpeed <= enemy.timeSinceLastAttack)
    //    {
    //        Attack(enemy, target);
    //        enemy.timeSinceLastAttack = 0;
    //    }
    //}

    public override void FixedUpdate(EnemyStateManager enemy)
    {
        
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
        
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {
        if(enemy.currentCollision == null)
        {
            enemy.SwitchState(enemy.MoveState);
        }
        else
        {
            enemy.target = enemy.currentCollision.gameObject;
        }
    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.target = null;
            enemy.SwitchState(enemy.MoveState);
        }
        
    }
    private void TurnToTarget(EnemyStateManager enemy, GameObject target)
    {
        if (enemy.currentCollision == null) return;
        if (enemy.transform.position.x > target.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (enemy.transform.position.x < target.transform.position.x)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void Attack(EnemyStateManager enemy, GameObject target)
    {
        if (target == null)
        {
            Debug.Log(enemy.gameObject.name + "'s target is null");
            if (enemy.currentCollision.transform.CompareTag("Fence"))
            {
                enemy.target = enemy.currentCollision.gameObject;
            }
            else if (enemy.currentCollision.transform.CompareTag("Player"))
            {
                if (enemy.currentCollision.transform.GetComponent<PlayerHealth>().GetIsPlayerDead())
                {
                    enemy.SwitchState(enemy.MoveState);
                }
                else
                {
                    enemy.target = enemy.currentCollision.gameObject;
                }
            }
            else
            {
                enemy.SwitchState(enemy.MoveState);
            }
            return;
        }
        TurnToTarget(enemy, target);

        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Attack");
    }

    

    




}
