using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject weaponPrefab = null;
    [SerializeField] private float weaponRange = 100f;
    [SerializeField] private float shakeIntensity = 3;
    [SerializeField] private float weaponDamage = 5;


    public void Spawn(Transform weaponMainTransform)
    {
        Instantiate(weaponPrefab, weaponMainTransform);
    }

    public float GetWeaponDamage()
    {
        return weaponDamage;
    }

    public float GetWeaponRange()
    {
        return weaponRange;
    }

    public float GetShakeIntensity()
    {
        return shakeIntensity;
    }
}