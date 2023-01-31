using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("ya");
        EnemyDie(enemy);
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

    public void EnemyDie(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.DeathState);
        Debug.Log("enemy died");
        UnityEngine.Object.Destroy(enemy.gameObject);
    }


}
