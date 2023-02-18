using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] private float fenceHealth = 500;
    [SerializeField] private int fenceLineID;
    [SerializeField] private GameObject enemyThatAttacksThisFence = null;
    public void FenceGetDamage(float damage)
    {
        fenceHealth = Mathf.Max(fenceHealth - damage, 0);
        if (fenceHealth == 0)
        {
            enemyThatAttacksThisFence.GetComponent<EnemyStateManager>().destroyedAFence = true;
            DestroyFence();
        }
    }

    
    private void DestroyFence()
    {
        Destroy(gameObject);
    }

    public float GetFenceHealth()
    {
        return fenceHealth;
    }

    public int GetFenceLineID()
    {
        return fenceLineID;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int enemyLineID = collision.gameObject.GetComponent<EnemyStateManager>().GetEnemyLineID();
            if (enemyLineID == fenceLineID)
            {
                enemyThatAttacksThisFence = collision.gameObject;
                enemyThatAttacksThisFence.GetComponent<EnemyStateManager>().target = gameObject;
            }
        }
        
    }

}
