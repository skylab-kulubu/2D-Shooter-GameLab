using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFence : FenceController
{
    [SerializeField] private const float woodFenceHealth = 250;
    [SerializeField] private const int requiredWoodToFix = 25;
    [SerializeField] private GameObject woodFencePrefab;

    public float GetWoodFenceHealthPoints()
    {
        return woodFenceHealth;
    }
    public int GetRequiredWoodToFix()
    {
        return requiredWoodToFix;
    }
    public GameObject GetWoodFencePrefab()
    {
        return woodFencePrefab;
    }
}
