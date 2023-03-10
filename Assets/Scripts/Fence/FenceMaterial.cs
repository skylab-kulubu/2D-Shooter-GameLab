using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "FenceMaterial", menuName = "FenceMaterials/Create New FenceMaterial", order = 0)]

public class FenceMaterial : ScriptableObject
{
    [SerializeField] private SpriteRenderer fenceMaterialSpriteRenderer;
    [SerializeField] private Sprite fenceMaterialIcon;

    public SpriteRenderer GetFenceMaterialSpriteRenderer()
    {
        return fenceMaterialSpriteRenderer;
    }
    public Sprite GetFenceMaterialIcon()
    {
        return fenceMaterialIcon;
    }
    
}

