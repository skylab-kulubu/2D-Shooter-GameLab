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
    public EnemyRunsToVillageState RunToVillageState = new EnemyRunsToVillageState();

    public EnemyStats enemyStats;
    public float currentHealthPoints;

    public float enemyAttackSpeed;
    public float timeSinceLastAttack = 0;

    public bool isDead = false;

    public float damageTaken;

    public Collision2D currentCollision;

    public GameObject target;

    public bool enemyAttacksPlayer = false;

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
        print(currentState);
        Debug.Log("target " +target);
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
        print("currentCollision: " + currentCollision.transform.name);
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

    public void HitEvent(EnemyStateManager enemy, GameObject target)
    {
        float damage = enemy.enemyStats.GetDamage();

        if (target.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerHealth>().PlayerGetDamage(damage);
        }
        else if (target.gameObject.tag == "Fence")
        {
            target.GetComponent<Fence>().FenceGetDamage(damage);
        }
    }



}
