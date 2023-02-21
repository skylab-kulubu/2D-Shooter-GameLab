using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint11;
    [SerializeField] private Transform spawnPoint21;
    [SerializeField] private Transform spawnPoint31;
    [SerializeField] private Transform spawnPoint41;
    [SerializeField] private Transform spawnPoint12;
    [SerializeField] private Transform spawnPoint22;
    [SerializeField] private Transform spawnPoint32;
    [SerializeField] private Transform spawnPoint42;

    [SerializeField] private GameObject goblin;
    [SerializeField] private GameObject flyingEye;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject mushroom;

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private List<Transform> line1 = new List<Transform>();
    [SerializeField] private List<Transform> line2 = new List<Transform>();
    [SerializeField] private List<Transform> line3 = new List<Transform>();
    [SerializeField] private List<Transform> line4 = new List<Transform>();

    public static int enemyKilled = 0;

    private Transform previousSpawnPoint;


    private void Start()
    {

        StartCoroutine(SpawnEnemyInARow(10));

    }
    private void SpawnEnemy()
    {
        GameObject enemy = RandomEnemyPicker();
        Transform spawnPoint = RandomSpawnPointGenerator(enemy);
        if(previousSpawnPoint != null)
        {
            while(spawnPoint == previousSpawnPoint)
            {
                spawnPoint = RandomSpawnPointGenerator(enemy);
            }
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }

        previousSpawnPoint = spawnPoint;
    }

    private GameObject RandomEnemyPicker()
    {
        int listSize = enemies.Count;
        int randomIndex = UnityEngine.Random.Range(0, listSize);
        Debug.Log("gameobject listSize " + listSize);
        Debug.Log("gameobject randomIndex " + randomIndex);

        GameObject randomEnemy = enemies[randomIndex];
        return randomEnemy;
    }

    private Transform RandomSpawnPointGenerator(GameObject enemy)
    {
        int randomLineID = UnityEngine.Random.Range(1, 5);
        if(randomLineID == 1)
        {
            int lineListSize = line1.Count;
            int randomSpawnPointID = UnityEngine.Random.Range(0, lineListSize);
            enemy.GetComponent<EnemyStateManager>().enemyLineID = randomLineID;
            enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = randomLineID.ToString();
            Transform transform = line1[randomSpawnPointID];
            Debug.Log("spawnPoint name: " + transform.name);

            return transform;

        }
        else if (randomLineID == 2)
        {
            int lineListSize = line2.Count;
            int randomSpawnPointID = UnityEngine.Random.Range(0, lineListSize);
            enemy.GetComponent<EnemyStateManager>().enemyLineID = randomLineID;
            enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = randomLineID.ToString();

            Transform transform = line2[randomSpawnPointID];
            Debug.Log("spawnPoint name: " + transform.name);

            return transform;

        }
        else if (randomLineID == 3)
        {
            int lineListSize = line3.Count;
            int randomSpawnPointID = UnityEngine.Random.Range(0, lineListSize);
            enemy.GetComponent<EnemyStateManager>().enemyLineID = randomLineID;
            enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = randomLineID.ToString();

            Transform transform = line3[randomSpawnPointID];
            Debug.Log("spawnPoint name: " + transform.name);

            return transform;

        }
        else if (randomLineID == 4)
        {
            int lineListSize = line4.Count;
            int randomSpawnPointID = UnityEngine.Random.Range(0, lineListSize);
            enemy.GetComponent<EnemyStateManager>().enemyLineID = randomLineID;
            enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = randomLineID.ToString();

            Transform transform = line4[randomSpawnPointID];
            Debug.Log("spawnPoint name: " + transform.name);

            return transform;
        }
        Debug.LogError("spawnpoint is null");
        return null;
    }

    private IEnumerator SpawnEnemyInARow(int enemyNumber)
    {
        for (int j = 0; j < Mathf.Ceil(enemyNumber / 3) ; j++)
        {
            Debug.Log("kulanýlýormuymuþ");
            for (int i = 0; i < 4; i++)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(2f);
        }
        
    }

    
}
