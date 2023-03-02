using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunsToVillageState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.enemyWasRunningToVillage = true;
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
    }

    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D collision)
    {
    }

    public override void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision)
    {
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
    }

    
}
