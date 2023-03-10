using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "FenceMaterial", menuName = "FenceMaterials/Create New FenceMaterial", order = 0)]

public class FenceMaterial : ScriptableObject
{
    [SerializeField] private Color fenceMaterialICon;

    public Color GetFenceMaterialIcon()
    {
        return fenceMaterialICon;
    }
}