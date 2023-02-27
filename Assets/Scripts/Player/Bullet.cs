using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Bullet : ScriptableObject
{
    [SerializeField] private GameObject bulletPrefab = null;
}

