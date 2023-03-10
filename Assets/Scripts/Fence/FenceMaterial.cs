using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "FenceMaterial", menuName = "FenceMaterials/Create New FenceMaterial", order = 0)]

public class FenceMaterial : ScriptableObject
{
    [SerializeField] public SpriteRenderer fenceMaterialICon;

    public SpriteRenderer GetFenceMaterialIcon()
    {
        return fenceMaterialICon;
    }
}

