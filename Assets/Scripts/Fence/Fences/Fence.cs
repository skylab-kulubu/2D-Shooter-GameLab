using UnityEngine;
[CreateAssetMenu(fileName = "Fence", menuName = "Fences/Create New Fence", order = 0)]

public class Fence : ScriptableObject
{
    [SerializeField] private float mainFenceHealth;
    [SerializeField] private FenceMaterial fenceMaterial;
    [SerializeField] private Fence nextFence;
    [SerializeField] private int requiredMaterialToUpgrade;
    [SerializeField] private int requiredMaterialToFix;
    [SerializeField] GameObject fencePrefab;
    [SerializeField] bool endOfTheUpgrades = false;


    public float GetFenceHealthPoints()
    {
        return mainFenceHealth;
    }
    public int GetRequiredMaterialToFix()
    {
        return requiredMaterialToFix;
    }
    public int GetRequiredMaterialToUpgrade()
    {
        return requiredMaterialToUpgrade;
    }
    public GameObject GetFencePrefab()
    {
        return fencePrefab;
    }
    public FenceMaterial GetFenceMaterial()
    {
        return fenceMaterial;
    }
    public bool GetEndOfTheUpgrades()
    {
        return endOfTheUpgrades;
    }
    public Fence GetNextFence()
    {
        return nextFence;
    }
}
