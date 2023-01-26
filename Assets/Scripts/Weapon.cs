using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject weaponPrefab = null;

    public void Spawn(Transform weaponMainTransform)
    {
        Instantiate(weaponPrefab, weaponMainTransform);
    }
}