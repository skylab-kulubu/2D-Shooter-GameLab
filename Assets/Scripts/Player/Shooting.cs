using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using System.Linq;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float lnOnFor = 0.1f;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private float shakeTimer = 0;

    [SerializeField] Transform weaponMainTransform;
    [SerializeField] Weapon defaultWeapon = null;

    [SerializeField] List<GameObject> currentMagazine = new List<GameObject>();
    Weapon currentWeapon = null;

    [SerializeField] private Transform firePoint = null;


    private float sinceLastShoot = 0;

    private Vector2 shootingVector;

    private float shootingDirection;

    private GameObject bullet = null;


    private void Start()
    {
        EquipWeapon(defaultWeapon);

        int defaultBulletAmount = currentWeapon.GetDefaultBulletAmount();
        LoadMagazine(currentMagazine, defaultBulletAmount);

        //firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
    }

    private void LoadMagazine(List<GameObject> magazine, int bulletAmount)
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            if (currentWeapon == null)
            {
                Debug.LogError("Current Weapon is null");
            }
            else
            {
                if (magazine.ToArray().Length >= currentWeapon.GetMagazineCapacity()) return;

                bullet = Instantiate(currentWeapon.GetBullet().GetBulletPrefab(), gameObject.transform);
                magazine.Add(bullet);
            }

        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        weapon.Spawn(weaponMainTransform);


    }

    private void Update()
    {
        sinceLastShoot += Time.deltaTime;
        SetShootingDirection();

        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (sinceLastShoot > currentWeapon.GetBulletFrequency())
            {
                HitTheTrigger();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadMagazine(currentMagazine, currentWeapon.GetMagazineCapacity());
        }


    }

    private void SetShootingDirection()
    {
        if (Mathf.Sign(transform.localScale.x) == 1)
        {
            shootingDirection = currentWeapon.GetWeaponRange();
        }
        else if (Mathf.Sign(transform.localScale.x) == -1)
        {
            shootingDirection = -currentWeapon.GetWeaponRange();
        }
    }
    private void HitTheTrigger()
    {
        if (currentMagazine.ToArray().Length > 0)
        {
            StartCoroutine(Shoot());
            Debug.Log(currentMagazine.ToArray().Length);
            currentMagazine.RemoveAt(0);

        }
        else
        {
            Debug.Log("magazine is empty");
        }
    }
    private IEnumerator Shoot()
    {
        ShakeCamera(currentWeapon.GetShakeIntensity(), .1f);
        shootingVector = transform.right;
        sinceLastShoot = 0;

        if (!currentWeapon.GetIsShot())
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(firePoint.position, shootingVector, shootingDirection);
            GameObject hittedEnemy = hits.Where(hit => hit.collider.CompareTag("Enemy")).Select(hit => hit.collider.gameObject).FirstOrDefault();

            if (hittedEnemy != null)
            {
                EnemyStateManager enemyStateManager = hittedEnemy.transform.GetComponent<EnemyStateManager>();
                enemyStateManager.GetAmountofDamage(currentWeapon.GetWeaponDamage());
                enemyStateManager.SwitchState(enemyStateManager.TakeDamageState);
            }
            else
            {
                Debug.Log("Missed");
            }

            if (currentWeapon.GetIsInFighting()) yield break;

            LineRenderer lineRenderer = bullet.GetComponent<LineRenderer>();
            if (lineRenderer == null) Debug.LogError("LineRenderer is null");
            lineRenderer.enabled = true;
            lineRenderer.SetPositions(new Vector3[] { firePoint.position, firePoint.position + Vector3.right * shootingDirection });
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            yield return new WaitForSeconds(lnOnFor);
            lineRenderer.startWidth = 0f;
            lineRenderer.endWidth = 0f;
        }
        else
        {
            List<float> angles = new List<float> { UnityEngine.Random.Range(45, 91), UnityEngine.Random.Range(-45, 46), UnityEngine.Random.Range(-90, -44) };

            foreach (float angle in angles)
            {
                for (int i = 0; i < 2; i++)
                {
                    RaycastHit2D[] bulletHits = Physics2D.RaycastAll(firePoint.position, shootingVector * angle, shootingDirection);
                    foreach (RaycastHit2D hit in bulletHits)
                    {
                        if (hit.transform.CompareTag("Enemy"))
                        {
                            hit.transform.GetComponent<EnemyStateManager>().GetAmountofDamage(currentWeapon.GetWeaponDamage());
                            hit.transform.GetComponent<EnemyStateManager>().SwitchState(hit.transform.GetComponent<EnemyStateManager>().TakeDamageState);
                        }
                    }

                    LineRenderer lineRenderer = bullet.GetComponent<LineRenderer>();
                    if (lineRenderer == null) Debug.LogError("LineRenderer is null");
                    lineRenderer.SetPositions(new Vector3[] { firePoint.position, firePoint.position + Vector3.right * shootingDirection });
                    lineRenderer.startWidth = 0.1f;
                    lineRenderer.endWidth = 0.1f;
                    yield return new WaitForSeconds(lnOnFor);
                    lineRenderer.startWidth = 0f;
                    lineRenderer.endWidth = 0f;
                }
            }
        }
    }


    public void ShakeCamera(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = timer;
    }




}