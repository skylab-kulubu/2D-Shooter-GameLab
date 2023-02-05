using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/New Enemy", order = 0)]

public class EnemyStats : ScriptableObject
{
    [SerializeField] private float healthPoints;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float attackSpeed;

    public float GetSpeed()
    {
        return speed;
    }

    public float GetHealthPoints()
    {
        return healthPoints;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
}
