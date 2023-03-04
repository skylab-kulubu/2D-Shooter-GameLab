using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager enemy);
    public abstract void UpdateState(EnemyStateManager enemy);
    public abstract void FixedUpdate(EnemyStateManager enemy);
    public abstract void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision);
    public abstract void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision);
    public abstract void OnTriggerExit2D(EnemyStateManager enemy, Collider2D collision);
    public abstract void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision);
    public abstract void OnCollisionStay2D(EnemyStateManager enemy, Collision2D collision);
    public abstract void OnCollisionExit2D(EnemyStateManager enemy, Collision2D collision);

}