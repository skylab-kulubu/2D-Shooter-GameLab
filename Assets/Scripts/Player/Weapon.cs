using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject equippedPrefab = null;
    [SerializeField] private float weaponRange = 100f;
    [SerializeField] private float shakeIntensity = 3;
    [SerializeField] private float weaponDamage = 5;
    [SerializeField] private int magazineCapacity = 0;
    [SerializeField] private int defaultBulletAmount = 0;

    [SerializeField] private bool isInFighting = false;
    [SerializeField] private float bulletFrequency = 1;
    [SerializeField] private bool isShot = false;
    [SerializeField] private Bullet bullet = null;

    //[SerializeField] private Transform firePointWeapon = null;


    public void Spawn(Transform weaponMainTransform)
    {
        if(equippedPrefab != null)
        {
            Instantiate(equippedPrefab, weaponMainTransform);
        }
    }

    public int GetMagazineCapacity()
    {
        return magazineCapacity;
    }

    public int GetDefaultBulletAmount()
    {
        return defaultBulletAmount;
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

    public bool GetIsShot()
    {
        return isShot;
    }

    public Bullet GetBullet()
    {
        return bullet;
    }

    //public Transform GetFirePoint()
    //{
    //    return firePointWeapon;
    //}
}