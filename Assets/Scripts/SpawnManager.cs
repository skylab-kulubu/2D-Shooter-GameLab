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

    [SerializeField] private GameObject marketPanel;
    [SerializeField] private bool isReadyForNextWave = false;

    [SerializeField] private GameObject breakTimeElements;

    [SerializeField] private GameObject enemyHolder;

    [SerializeField] private List<GameObject> weaponButtons = new List<GameObject>();


    public static int enemyDestroyed = 0;

    private Transform previousSpawnPoint;

    private int starterEnemyNumber = 4;

    [SerializeField] private float currentBreakTime = 0;
    [SerializeField] private float breakTime = 30;


    [SerializeField] private int createdEnemyNumber = 0;
    private void Start()
    {
        currentBreakTime = breakTime;
        StartCoroutine(SpawnEnemyInARow(starterEnemyNumber));

    }
    private void Update()
    {
        int enemiesThatActive = 0;

        EnemyStateManager[] enemiesPool = enemyHolder.GetComponentsInChildren<EnemyStateManager>();
        foreach (EnemyStateManager enemyStateManager in enemiesPool)
        {
            if (!enemyStateManager.gameObject.activeInHierarchy)
            {
                enemiesThatActive--;
            }
            else
            {
                enemiesThatActive++;
            }

        }
        if(enemiesThatActive == 0)
        {
            currentBreakTime -= Time.deltaTime;
            breakTimeElements.SetActive(true);
            if (currentBreakTime <= 0)
            {
                isReadyForNextWave = true;
            }
            if (isReadyForNextWave)
            {
                ActiveNextWeapon();
                breakTimeElements.SetActive(false);
                StartCoroutine(SpawnEnemyInARow(starterEnemyNumber + 1));
                currentBreakTime = breakTime;
                starterEnemyNumber++;
            }
        }
        
    }

    private void ActiveNextWeapon()
    {
        int firstIndex = 0;
        foreach (GameObject wepaonButton in weaponButtons)
        {
            if (weaponButtons[firstIndex].activeInHierarchy)
            {
                firstIndex++;
            }
            else
            {
                weaponButtons[firstIndex].SetActive(true);
                return;
            }
        }
    }

    private IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    private void SpawnEnemy()
    {
        createdEnemyNumber++;
        GameObject enemy = RandomEnemyPicker();
        Transform spawnPoint = RandomSpawnPointGenerator(enemy);
        if(previousSpawnPoint != null)
        {
            while(spawnPoint == previousSpawnPoint)
            {
                spawnPoint = RandomSpawnPointGenerator(enemy);
                StartCoroutine(WaitForSeconds(0.5f));
            }
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = Quaternion.identity;
        }
        else
        {
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = Quaternion.identity;
        }
        enemy.GetComponent<EnemyStateManager>().SwitchState(enemy.GetComponent<EnemyStateManager>().MoveState);
        enemy.GetComponent<EnemyStateManager>().currentHealthPoints = enemy.GetComponent<EnemyStateManager>().enemyStats.GetHealthPoints();

        enemy.GetComponentInChildren<EnemyHealthBar>().gameObject.SetActive(true);
        previousSpawnPoint = spawnPoint;
    }

    private GameObject RandomEnemyPicker()
    {
        int listSize = enemies.Count;
        int randomIndex = UnityEngine.Random.Range(0, listSize);

        GameObject randomEnemy = GetComponent<EnemyPool>().GetEnemy(randomIndex);
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

            return transform;

        }
        else if (randomLineID == 2)
        {
            int lineListSize = line2.Count;
            int randomSpawnPointID = UnityEngine.Random.Range(0, lineListSize);
            enemy.GetComponent<EnemyStateManager>().enemyLineID = randomLineID;
            enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = randomLineID.ToString();

            Transform transform = line2[randomSpawnPointID];

            return transform;

        }
        else if (randomLineID == 3)
        {
            int lineListSize = line3.Count;
            int randomSpawnPointID = UnityEngine.Random.Range(0, lineListSize);
            enemy.GetComponent<EnemyStateManager>().enemyLineID = randomLineID;
            enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = randomLineID.ToString();

            Transform transform = line3[randomSpawnPointID];

            return transform;

        }
        else if (randomLineID == 4)
        {
            int lineListSize = line4.Count;
            int randomSpawnPointID = UnityEngine.Random.Range(0, lineListSize);
            enemy.GetComponent<EnemyStateManager>().enemyLineID = randomLineID;
            enemy.GetComponentInChildren<SpriteRenderer>().sortingLayerName = randomLineID.ToString();

            Transform transform = line4[randomSpawnPointID];

            return transform;
        }
        Debug.LogError("spawnpoint is null");
        return null;
    }

    private IEnumerator SpawnEnemyInARow(int enemyNumber)
    {
        //for (int j = 0; j < Mathf.Ceil(enemyNumber / 3) ; j++)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        SpawnEnemy();
        //    }
        //    yield return new WaitForSeconds(2f);
        //}
        for (int i = 0; i < enemyNumber; i++)
        {
            SpawnEnemy();
        }
        yield return new WaitForSeconds(2f);
        isReadyForNextWave = false;
    }

    public void SetReadyForNextWaveTrue()
    {
        isReadyForNextWave = true;
    }

    public float GetBreakTime()
    {
        return Mathf.FloorToInt(currentBreakTime);
    }

}
