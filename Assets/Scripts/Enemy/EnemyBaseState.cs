using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager enemy);
    public abstract void UpdateState(EnemyStateManager enemy);
    public abstract void FixedUpdate(EnemyStateManager enemy);
    public abstract void OnCollisionEnter2D(EnemyStateManager enemy, Collision2D collision);

}
