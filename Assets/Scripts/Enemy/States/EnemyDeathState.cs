using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        
        enemy.isDead = true;
        enemy.StartCoroutine(EnemyDie(enemy));
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

    public IEnumerator EnemyDie(EnemyStateManager enemy)
    {

        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Death");

        Collider2D[] colliders = enemy.GetComponents<Collider2D>();

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        yield return new WaitForSeconds(5f);

        enemy.gameObject.SetActive(false);
    }

    public override void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision)
    {

    }

    public override void OnTriggerExit2D(EnemyStateManager enemy, Collider2D collision)
    {

    }
}
