using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        //if(enemy.target != null)
        //{
        //    enemy.SwitchState(enemy.AttacksPlayerState);
        //}
        enemy.enemyAttacksPlayer = false;
        enemy.enemyAttacksFence = false;
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

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Fence"))
        {

            float fenceId = collision.gameObject.GetComponent<Fence>().GetFenceLineID();
            float enemyId = enemy.enemyLineID;


            collision.gameObject.GetComponent<Fence>().enemiesThatAttacksThisFence.Add(enemy.gameObject);

            enemy.SwitchState(enemy.AttacksFenceState);
            enemy.target = collision.gameObject;




        }
    }
    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D collision)
    {
    }

    public override void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision)
    {

        if (collision != null)
        {
            
            if (collision.gameObject.tag == "Fence")
            {
                enemy.SwitchState(enemy.AttacksFenceState);
                enemy.target = collision.gameObject;
            }
        }
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
    }
    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.SwitchState(enemy.AttacksPlayerState);
            enemy.target = collision.gameObject;
        }
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                enemy.target = collision.gameObject;
                enemy.SwitchState(enemy.AttacksPlayerState);
            }
        }
    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {
    }

}


