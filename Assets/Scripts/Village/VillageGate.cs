using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SpawnManager.enemyDestroyed++;
            float damage = collision.gameObject.GetComponent<EnemyStateManager>().enemyStats.GetDamage();
            VillageHealth.villageHealthPoints = Mathf.Max(VillageHealth.villageHealthPoints - damage, 0);
            if (VillageHealth.villageHealthPoints == 0)
            {

            }
            Destroy(collision.gameObject);
        }
    }
}
