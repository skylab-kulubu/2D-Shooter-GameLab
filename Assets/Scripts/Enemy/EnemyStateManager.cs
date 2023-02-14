using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState currentState;

    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyDeathState DeathState = new EnemyDeathState();
    public EnemyTakeDamageState TakeDamageState = new EnemyTakeDamageState();
    public EnemyMoveState MoveState = new EnemyMoveState();

    public EnemyStats enemyStats;
    public float currentHealthPoints;

    public float enemyAttackSpeed;
    public float timeSinceLastAttack = 0;

    public bool isDead = false;

    public float damageTaken;

    public Collision2D currentCollision;

    void Start()
    {
        currentHealthPoints = enemyStats.GetHealthPoints();
        enemyAttackSpeed = enemyStats.GetAttackSpeed();
        currentState = MoveState;
        currentState.EnterState(this);
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        Debug.Log("current state: " + currentState);
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        currentCollision = collision;
        currentState.OnCollisionStay2D(this, collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentState.OnCollisionExit2D(this, collision);
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



}
