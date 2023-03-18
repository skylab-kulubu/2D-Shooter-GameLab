using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Bullets/Make New Bullet", order = 0)]
public class Bullet : ScriptableObject
{
    [SerializeField] private GameObject bulletPrefab = null;

    public GameObject GetBulletPrefab()
    {
        return bulletPrefab;
    }
}

