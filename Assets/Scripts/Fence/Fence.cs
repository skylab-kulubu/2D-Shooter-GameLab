using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] private float fenceHealth = 500;
    [SerializeField] private int fenceLineID;
    public List<GameObject> enemiesThatAttacksThisFence = new List<GameObject>();

    private Fence currentFence;
    private GameObject currentFencePrefab;
    private Fence nextFence;
    private GameObject fenceMaterial;
    private bool hasWeaponOnIt = false;
    private bool readyToUpgrade = false;
    private bool readyToFix = false;



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


    public int GetFenceLineID()
    {
        return fenceLineID;
    }

    public void SetFenceHealth(float health)
    {
        fenceHealth = health;
    }
    public float GetFenceHealth()
    {
        return fenceHealth;
    }

    public void SetHasWeapon(bool trueOrFalse)
    {
        hasWeaponOnIt = trueOrFalse;
    }

    public bool GetHasWeapon()
    {
        return hasWeaponOnIt;
    }

    public void SetCurrentFence(Fence fence)
    {
        currentFence = fence;
    }
    public Fence GetCurrentFence()
    {
        return currentFence;
    }

    public void SetReadyToUpgrade(bool trueOrFalse)
    {
        readyToUpgrade = trueOrFalse;
    }
    public bool GetReadyToUpgrade()
    {
        return readyToUpgrade;
    }

    public void SetReadyToFix(bool trueOrFalse)
    {
        readyToFix = trueOrFalse;
    }
    public bool GetReadyToFix()
    {
        return readyToFix;
    }

    public void SetCurrentFencePrefab(GameObject fencePrefab)
    {
        currentFencePrefab = fencePrefab;
    }

    public void SetNextFence(Fence fence)
    {
        nextFence = fence;
    }
    public void SetCurrentFenceMaterial(GameObject fenceMaterial)
    {
        this.fenceMaterial = fenceMaterial;
    }


}
