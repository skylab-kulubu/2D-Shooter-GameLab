using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/New Enemy", order = 0)]

public class EnemyStats : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
}
