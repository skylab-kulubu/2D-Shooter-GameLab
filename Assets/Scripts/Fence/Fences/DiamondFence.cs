using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondFence : Fence
{
    [SerializeField] private const float diamondFenceHealth = 1000;
    [SerializeField] private const int requiredDiamondToFix = 100;
    [SerializeField] private const int requiredDiamondToUpgrade = 200;
    [SerializeField] private GameObject diamondFencePrefab;

    public float GetDiamondFenceHealthPoints()
    {
        return diamondFenceHealth;
    }
    public int GetRequiredDiamondToFix()
    {
        return requiredDiamondToFix;
    }
    public int GetRequiredDiamondToUpgrade()
    {
        return requiredDiamondToUpgrade;
    }
    public GameObject GetDiamondFencePrefab()
    {
        return diamondFencePrefab;
    }
}
