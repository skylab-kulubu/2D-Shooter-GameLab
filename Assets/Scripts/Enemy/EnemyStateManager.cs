using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyDeathState DeathState = new EnemyDeathState();
    public EnemyTakeDamageState TakeDamageState = new EnemyTakeDamageState();
    public EnemyStats enemyStats;
    public float currentHealthPoints;

    public float damageTaken;

    void Start()
    {
        currentHealthPoints = enemyStats.GetHealthPoints();
        currentState = AttackState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    void FixedUpdate()
    {
        currentState.FixedUpdate(this);
    }

    public void GetAmountofDamage(float amountofDamage)
    {
        damageTaken = amountofDamage;
    }

    public void EnemyDie()
    {
    }


}
