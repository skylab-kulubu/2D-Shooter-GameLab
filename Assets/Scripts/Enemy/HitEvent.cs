using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    void Hit()
    {
        EnemyStateManager enemy = GetComponentInParent<EnemyStateManager>();
        GameObject target = GetComponentInParent<EnemyStateManager>().target;
        GetComponentInParent<EnemyStateManager>().HitEvent(enemy, target);
    }
}
