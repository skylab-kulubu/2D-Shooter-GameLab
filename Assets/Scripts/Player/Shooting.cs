using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Shooting : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float lnOnFor = 0.1f;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private float shakeTimer = 0;

    [SerializeField] Transform weaponMainTransform;
    [SerializeField] Weapon defaultWeapon = null;
    Weapon currentWeapon = null;

    [SerializeField] private Transform firePoint = null;


    private float sinceLastShoot = 0;

    private Vector2 shootingVector;

    private float shootingDirection;




    private void Start()
    {
        EquipWeapon(defaultWeapon);
        //firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
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
                StartCoroutine(Shoot());
            }
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
    private IEnumerator Shoot()
    {
        ShakeCamera(currentWeapon.GetShakeIntensity(), .1f);
        shootingVector = transform.right;
        sinceLastShoot = 0;

        if (!currentWeapon.GetIsShot())
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(firePoint.position, shootingVector, shootingDirection);
            GameObject hittedEnemy = null;
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    hittedEnemy = hit.collider.gameObject;
                    break;
                }
            }

            if (hittedEnemy != null)
            {

                hittedEnemy.transform.GetComponent<EnemyStateManager>().GetAmountofDamage(currentWeapon.GetWeaponDamage());
                hittedEnemy.transform.GetComponent<EnemyStateManager>().SwitchState(hittedEnemy.transform.GetComponent<EnemyStateManager>().TakeDamageState);
            }
            else
            {
                // Did not hit anything
                Debug.Log("Missed");
            }

            if (currentWeapon.GetIsInFighting()) yield break;

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;

            lineRenderer.SetPosition(1, (firePoint.position + Vector3.right * shootingDirection));

            yield return new WaitForSeconds(lnOnFor);
            lineRenderer.startWidth = 0f;
            lineRenderer.endWidth = 0f;
        }
        else
        {
            List<GameObject> hittedEnemies = null;
            float angleA = UnityEngine.Random.Range(45, 91);
            float angleB = UnityEngine.Random.Range(-45, 46);
            float angleC = UnityEngine.Random.Range(-90, -44);


            for (int i = 0; i < 3; i++)
            {
                float angle = (i == 0 ? angleA : (i == 1 ? angleB : angleC));
                for (int j = 0; j < 2; j++)
                {
                    RaycastHit2D[] bulletHits = Physics2D.RaycastAll(firePoint.position, shootingVector * angle, shootingDirection);
                    foreach (RaycastHit2D hit in bulletHits)
                    {
                        if (hit.transform.CompareTag("Enemy"))
                        {
                            hit.transform.GetComponent<EnemyStateManager>().GetAmountofDamage(currentWeapon.GetWeaponDamage());
                            hit.transform.GetComponent<EnemyStateManager>().SwitchState(hit.transform.GetComponent<EnemyStateManager>().TakeDamageState);

                            hittedEnemies.Add(hit.transform.gameObject);
                        }
                    }
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