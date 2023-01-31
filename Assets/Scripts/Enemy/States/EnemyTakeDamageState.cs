using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        TakeDamage(enemy, enemy.damageTaken);       
    }

    public override void FixedUpdate(EnemyStateManager enemy)
    {
    }

    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {

    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public void TakeDamage(EnemyStateManager enemy, float amountDamage)
    {
        enemy.currentHealthPoints = Mathf.Max(enemy.currentHealthPoints - amountDamage, 0);
        if (enemy.currentHealthPoints == 0)
        {
            Object.Destroy(enemy.gameObject);
        }
    }
}
