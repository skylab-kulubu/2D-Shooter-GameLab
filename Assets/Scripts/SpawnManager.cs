using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    [SerializeField] private Transform spawnPoint4;

    [SerializeField] private GameObject goblin;
    [SerializeField] private GameObject flyingEye;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject mushroom;

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        GameObject enemy = RandomEnemyPicker();
        Transform spawnPoint = RandomSpawnPointGenerator(enemy);


        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
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
        int listSize = spawnPoints.Count;
        int randomIndex = UnityEngine.Random.Range(0, listSize);
        enemy.GetComponent<EnemyStateManager>().enemyLineID = randomIndex + 1;
        enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = (randomIndex + 1).ToString();


        Debug.Log("transform listSize " + listSize);
        Debug.Log("transform randomIndex " + randomIndex);
        Debug.Log("spawnpoint name: " + spawnPoints[randomIndex].name);
        Transform transform = spawnPoints[randomIndex + 1];
        return transform;
    }
}
