using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] private float fenceHealth = 500;
    [SerializeField] private int fenceLineID;
    public List<GameObject> enemiesThatAttacksThisFence = new List<GameObject>();
    public void FenceGetDamage(float damage)
    {
        fenceHealth = Mathf.Max(fenceHealth - damage, 0);
        if (fenceHealth == 0)
        {
            foreach (GameObject enemy in enemiesThatAttacksThisFence)
            {
                enemy.GetComponent<EnemyStateManager>().destroyedAFence = true;
            }
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
        
        
    }

}
