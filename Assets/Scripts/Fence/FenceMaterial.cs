using UnityEngine;
[CreateAssetMenu(fileName = "FenceMaterial", menuName = "FenceMaterials/Create New FenceMaterial", order = 0)]

public class FenceMaterial : ScriptableObject
{
    [SerializeField] private GameObject fenceMaterialPrefab;
}
