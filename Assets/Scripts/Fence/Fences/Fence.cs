using UnityEngine;
[CreateAssetMenu(fileName = "Fence", menuName = "Fences/Create New Fence", order = 0)]

public class Fence : ScriptableObject
{
    [SerializeField] private float mainFenceHealth;
    [SerializeField] private FenceMaterial fenceMaterial;
    [SerializeField] private int requiredMaterialToUpgrade;
    [SerializeField] private int requiredMaterialToFix;
    [SerializeField] GameObject fencePrefab;

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
    public GameObject GetMaterialFencePrefab()
    {
        return fencePrefab;
    }
    public FenceMaterial GetFenceMaterial()
    {
        return fenceMaterial;
    }
}
