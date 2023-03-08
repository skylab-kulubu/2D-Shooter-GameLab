using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFence : FenceController
{
    [SerializeField] private const float rockFenceHealth = 200;
    [SerializeField] private const int requiredRockToFix = 50;
    [SerializeField] private const int requiredRockToUpgrade = 100;
    [SerializeField] private GameObject rockFencePrefab;

    public float GetRockFenceHealthPoints()
    {
        return rockFenceHealth;
    }
    public int GetRequiredRockToFix()
    {
        return requiredRockToFix;
    }
    public int GetRequiredRockToUpgrade()
    {
        return requiredRockToUpgrade;
    }
    public GameObject GetRockFencePrefab()
    {
        return rockFencePrefab;
    }
}
