using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject equippedPrefab = null;
    [SerializeField] private float weaponRange = 100f;
    [SerializeField] private float shakeIntensity = 3;
    [SerializeField] private float weaponDamage = 5;
    [SerializeField] private bool isInFighting = false;
    [SerializeField] private float bulletFrequency = 1;
    [SerializeField] private Transform firePoint = null;




    public void Spawn(Transform weaponMainTransform)
    {
        if(equippedPrefab != null)
        {
            Instantiate(equippedPrefab, weaponMainTransform);
        }
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

    public bool GetIsInFighting()
    {
        return isInFighting;
    }

    public float GetBulletFrequency()
    {
        return bulletFrequency;
    }

    public GameObject GetEquippedPrebaf()
    {
        return equippedPrefab;
    }

    public Vector3 GetFirePoint()
    {
        return firePoint.TransformPoint(firePoint.position);
    }
}