using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.StopCoroutine(TakeDamage(enemy, enemy.damageTaken));
        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Take Hit");

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        enemy.StartCoroutine(TakeDamage(enemy, enemy.damageTaken));
    }

    public override void FixedUpdate(EnemyStateManager enemy)
    {
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision)
    {

    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }

    public IEnumerator TakeDamage(EnemyStateManager enemy, float amountDamage)
    {
        enemy.currentHealthPoints = Mathf.Max(enemy.currentHealthPoints - amountDamage, 0);
        if (enemy.currentHealthPoints <= 0)
        {
            SpawnManager.enemyDestroyed++;
            Debug.Log(SpawnManager.enemyDestroyed);
            enemy.SwitchState(enemy.DeathState);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            if (enemy.isDead)
            {
                enemy.SwitchState(enemy.DeathState);
            }
            else
            {
                if (enemy.enemyWasRunningToVillage)
                {
                    enemy.SwitchState(enemy.RunToVillageState);

                }
                else if(enemy.enemyAttacksFence)
                {
                    enemy.SwitchState(enemy.AttacksFenceState);

                    //if(enemy.currentCollision != null && enemy.currentTrigger != null)
                    //{
                    //    enemy.target = enemy.currentTrigger.transform.gameObject;
                    //    enemy.SwitchState(enemy.AttacksFenceState);
                    //}
                    //if(enemy.currentTrigger != null)
                    //{
                    //    if (enemy.currentTrigger.CompareTag("Fence") )
                    //    {
                    //        enemy.target = enemy.currentTrigger.gameObject;
                    //        enemy.SwitchState(enemy.AttacksFenceState);
                    //    }
                    //    else
                    //    {
                    //        enemy.target = null;
                    //        enemy.SwitchState(enemy.MoveState);

                    //    }
                    //}
                    //else if (enemy.currentCollision != null)
                    //{
                    //    if (enemy.currentCollision.transform.CompareTag("Player"))
                    //    {
                    //        enemy.target = enemy.currentCollision.gameObject;
                    //        enemy.SwitchState(enemy.AttacksPlayerState);
                    //    }
                    //    else
                    //    {
                    //        enemy.target = null;
                    //        enemy.SwitchState(enemy.MoveState);
                    //    }
                    //}
                    //else
                    //{
                    //    enemy.target = null;
                    //    enemy.SwitchState(enemy.MoveState);
                    //}
                }
                else if (enemy.enemyAttacksPlayer)
                {
                    enemy.SwitchState(enemy.AttacksPlayerState);
                }
                else
                {
                    enemy.SwitchState(enemy.MoveState);
                }
            }
        }
        
    }

    public override void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision)
    {
    }

    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D collision)
    {
    }
    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {
    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {
    }
}
