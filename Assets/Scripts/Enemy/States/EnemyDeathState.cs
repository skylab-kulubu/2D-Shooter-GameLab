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

    public override void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision)
    {
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
    }

    public IEnumerator EnemyDie(EnemyStateManager enemy)
    {
        Animator animator = enemy.transform.GetChild(0).GetComponent<Animator>();
        animator.Play("Death");

        Collider2D collider = enemy.GetComponent<Collider2D>();
        collider.enabled = false;

        yield return new WaitForSeconds(5f);
        Debug.Log("enemy died");
        UnityEngine.Object.Destroy(enemy.gameObject);
    }

    public override void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision)
    {

    }

    public override void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision)
    {

    }
}
