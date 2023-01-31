using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currenState;
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyDeathState DeathState = new EnemyDeathState();
    public EnemyTakeDamageState TakeDamageState = new EnemyTakeDamageState();
    public EnemyStats enemyStats;

    void Start()
    {
        currenState = AttackState;
        currenState.EnterState(this);
    }

    void Update()
    {
        currenState.UpdateState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currenState.OnCollisionEnter2D(this, collision);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currenState = state;
        state.EnterState(this);
    }

    void FixedUpdate()
    {
        currenState.FixedUpdate(this);
    }

    
}
