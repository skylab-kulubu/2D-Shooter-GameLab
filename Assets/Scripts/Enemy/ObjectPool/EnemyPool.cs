using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public Queue<GameObject> enemies;
        public GameObject enemyPrefab;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;

    private void Awake()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].enemies = new Queue<GameObject>();

            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject enemy = Instantiate(pools[i].enemyPrefab);
                enemy.transform.parent = GameObject.Find("Enemies").transform;
                enemy.SetActive(false);

                pools[i].enemies.Enqueue(enemy);
            }
        }
    }

    public GameObject GetEnemy(int i)
    {
        GameObject enemy = pools[i].enemies.Dequeue();
        if (enemy.activeInHierarchy)
        {
            enemy = Instantiate(pools[i].enemyPrefab);
        }
        enemy.SetActive(true);
        pools[i].enemies.Enqueue(enemy);

        return enemy;
    }


}
