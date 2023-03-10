using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacksFenceState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.enemyAttacksPlayer = false;
        enemy.enemyAttacksFence = true;
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        Attack(enemy, enemy.target);
    }

    

    public override void FixedUpdate(EnemyStateManager enemy)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision)
    {
    }

    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.gameObject.tag == "Fence")
        {
            if (enemy.destroyedAFence)
            {
                enemy.SwitchState(enemy.RunToVillageState);
                enemy.target = null;
                enemy.enemyAttacksFence = false;
            }
            //else if(collision.gameObject == enemy.target)
            //{
            //    enemy.SwitchState(enemy.MoveState);
            //    enemy.target = null;
            //}
            //else if (!enemy.destroyedAFence)
            //{
            //    enemy.SwitchState(enemy.MoveState);
            //}
        }
    }

    public override void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision)
    {
        if (enemy.target == null)
        {
            enemy.SwitchState(enemy.MoveState);
        }
        else if(collision.gameObject.CompareTag("Fence"))
        {
            enemy.target = enemy.currentTrigger.gameObject;
        }
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {
    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {
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
            Debug.LogError(enemy.gameObject.name + "'s target is null");
            return;
        }
        TurnToTarget(enemy, target);

        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Attack");
    }

    
}
