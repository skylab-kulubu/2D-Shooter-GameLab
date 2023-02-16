using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] private float fenceHealth = 500;
    public void FenceGetDamage(float damage)
    {
        fenceHealth = Mathf.Max(fenceHealth - damage, 0);
        if (fenceHealth == 0)
        {
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
}
