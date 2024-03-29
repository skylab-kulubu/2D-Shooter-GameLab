using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState currentState;

    public EnemyAttacksPlayerState AttacksPlayerState = new EnemyAttacksPlayerState();
    public EnemyAttacksFenceState AttacksFenceState = new EnemyAttacksFenceState();
    public EnemyDeathState DeathState = new EnemyDeathState();
    public EnemyTakeDamageState TakeDamageState = new EnemyTakeDamageState();
    public EnemyMoveState MoveState = new EnemyMoveState();
    public EnemyRunsToVillageState RunToVillageState = new EnemyRunsToVillageState();

    public bool hittedEnemy = true;

    public EnemyStats enemyStats;
    public float currentHealthPoints;

    public float enemyAttackSpeed;
    public float timeSinceLastAttack = 0;

    public int enemyLineID;

    public bool isDead = false;

    public float damageTaken;

    public Collision2D currentCollision;
    public Collider2D currentTrigger;

    public GameObject target;

    public bool enemyAttacksPlayer = false;

    public bool enemyAttacksFence = false;

    public bool enemyWasRunningToVillage = false;

    public bool destroyedAFence = false;

    public BoxCollider2D takeDamageCollider;
    public BoxCollider2D hitFenceCollider;
    public GameObject healthBar;


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
        currentState.UpdateState(this);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(this, collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        currentTrigger = collision;
        currentState.OnTriggerStay2D(this, collision);

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.OnTriggerExit2D(this, collision);
        currentTrigger = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        currentCollision = collision;
        currentState.OnCollisionStay2D(this, collision);

        if (currentTrigger != null) print(gameObject.name + "'s currentCollision: " + currentCollision.transform.name);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentState.OnCollisionExit2D(this, collision);
        currentCollision = null;
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
        if (target == null) return;
        if (target.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerHealth>().PlayerGetDamage(damage);
        }
        else if (target.gameObject.tag == "Fence")
        {
            target.GetComponent<FenceController>().FenceGetDamage(damage);
        }
    }

    public int GetEnemyLineID()
    {
        return enemyLineID;
    }

}