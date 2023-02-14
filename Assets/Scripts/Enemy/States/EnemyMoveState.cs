using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.transform.localScale = new Vector3(1, 1, 1);
        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Run");
    }

    public override void FixedUpdate(EnemyStateManager enemy)
    {
        
        Vector2 moveVector = new Vector2(-2, 0);
        float speed = enemy.enemyStats.GetSpeed();

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.velocity = moveVector * speed * Time.deltaTime;
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
        Debug.Log(enemy.currentCollision);
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Fence")
        {
            enemy.SwitchState(enemy.AttackState);
        }
    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {

    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if(enemy.currentCollision != null)
        {
            if (enemy.currentCollision.gameObject.tag == "Player" || enemy.currentCollision.gameObject.tag == "Fence")
            {
                enemy.SwitchState(enemy.AttackState);
            }
        }
    }

}
