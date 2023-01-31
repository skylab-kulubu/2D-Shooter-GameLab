using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        

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
        
    }

    
}
