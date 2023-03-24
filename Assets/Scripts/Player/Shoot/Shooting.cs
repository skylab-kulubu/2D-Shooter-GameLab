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

    [SerializeField] private Weapon currentWeapon = null;

    [SerializeField] private Transform firePoint = null;

    [SerializeField] private BulletData bulletData;
    [SerializeField] private Transform bulletsTransform;

    [SerializeField] private AudioClip bulletHit;
    [SerializeField] private AudioClip closeHit;
    public BulletData BulletData { get { return bulletData; } }


    private float sinceLastShoot = 0;

    private Vector2 shootingVector;

    private float shootingDirection;

    //private Queue<GameObject> bullets = new Queue<GameObject>();


    private void Start()
    {
        BulletData.PistolBulletAmount = BulletData.Weapons[0].GetDefaultBulletAmount();
        BulletData.ShotgunBulletAmount = BulletData.Weapons[1].GetDefaultBulletAmount();
        BulletData.RifleBulletAmount = BulletData.Weapons[2].GetDefaultBulletAmount();



        EquipWeapon(defaultWeapon);

        int defaultBulletAmount = currentWeapon.GetDefaultBulletAmount();
        LoadMagazine(currentWeapon.GetCurrentMagazine(), defaultBulletAmount);

        //firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
    }



    public void LoadMagazine(List<GameObject> magazine, int bulletAmount)
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            if (currentWeapon == null)
            {
                Debug.LogError("Current Weapon is null");
            }
            else if (magazine.Count < currentWeapon.GetMagazineCapacity())
            {

                if (bulletsTransform.childCount < currentWeapon.GetMagazineCapacity())
                {
                    Debug.Log("instated");
                    GameObject bullet = Instantiate(currentWeapon.GetBullet().GetBulletPrefab(), bulletsTransform);
                    //bullets.Enqueue(bullet);
                    magazine.Add(bullet);
                }
                else
                {

                    //bullets.Enqueue(bulletsTransform.GetChild(bulletsTransform.childCount - 1).gameObject);
                    magazine.Add(bulletsTransform.GetChild(bulletsTransform.childCount - 1).gameObject);

                }


            }

        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        weapon.Spawn(weaponMainTransform);


    }

    private void Update()
    {
        UpdateMagazines();
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

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    CheckandHit();
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadMagazine(currentWeapon.GetCurrentMagazine(), currentWeapon.GetMagazineCapacity());
        }


    }

    public void CheckandHit()
    {
        if (sinceLastShoot > currentWeapon.GetBulletFrequency())
        {
            HitTheTrigger();
            
        }
    }

    private void UpdateMagazines()
    {
        if (currentWeapon.GetWeaponID() == 2)
        {
            BulletData.PistolBulletAmount = GetCurrentMagazine().Count;
        }
        else if (currentWeapon.GetWeaponID() == 3)
        {
            BulletData.ShotgunBulletAmount = GetCurrentMagazine().Count;
        }
        else if (currentWeapon.GetWeaponID() == 4)
        {
            BulletData.RifleBulletAmount = GetCurrentMagazine().Count;
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
        if (currentWeapon.GetIsInFighting())
        {
            HitWithTheWeapon();
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(currentWeapon.GunSound);
        }
        else
        {
            if (currentWeapon.GetCurrentMagazine().ToArray().Length > 0)
            {

                StartCoroutine(ShootWithTheGun());
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(currentWeapon.GunSound);
                currentWeapon.GetCurrentMagazine().RemoveAt(0);

            }
            else
            {
                Debug.Log("magazine is empty");
            }
        }

    }
    private IEnumerator ShootWithTheGun()
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
                //GetComponent<AudioSource>().volume = 0.1f;
                //GetComponent<AudioSource>().PlayOneShot(bulletHit);
                EnemyStateManager enemyStateManager = hittedEnemy.transform.GetComponent<EnemyStateManager>();
                enemyStateManager.GetAmountofDamage(currentWeapon.GetWeaponDamage());
                enemyStateManager.SwitchState(enemyStateManager.TakeDamageState);
            }


            //GameObject bullet = bullets.Dequeue();
            GameObject bullet = GetCurrentMagazine()[^1];
            LineRenderer lineRenderer = bullet.GetComponent<LineRenderer>();
            if (lineRenderer == null) Debug.LogError("LineRenderer is null");
            lineRenderer.enabled = true;
            lineRenderer.SetPositions(new Vector3[] { firePoint.position, firePoint.position + Vector3.right * shootingDirection });
            lineRenderer.startWidth = 0.01f;
            lineRenderer.endWidth = 0.01f;
            yield return new WaitForSeconds(lnOnFor);
            lineRenderer.startWidth = 0f;
            lineRenderer.endWidth = 0f;
            //bullets.Enqueue(bullet);
        }
        else
        {
            float[] angles = { UnityEngine.Random.Range(0, 15), UnityEngine.Random.Range(-15, 0) };

            foreach (float angle in angles)
            {
                for (int j = 0; j < 3; j++)
                {
                    RaycastHit2D[] bulletHits = Physics2D.RaycastAll(firePoint.position, Quaternion.Euler(0f, 0f, angle) * transform.right, shootingDirection);
                    foreach (RaycastHit2D hit in bulletHits)
                    {
                        if (hit.transform.CompareTag("Enemy"))
                        {
                            //GetComponent<AudioSource>().volume = 0.1f;
                            //GetComponent<AudioSource>().PlayOneShot(bulletHit);

                            hit.transform.GetComponent<EnemyStateManager>().GetAmountofDamage(currentWeapon.GetWeaponDamage());
                            hit.transform.GetComponent<EnemyStateManager>().SwitchState(hit.transform.GetComponent<EnemyStateManager>().TakeDamageState);


                        }

                    }
                    Debug.Log("ssa");
                    GameObject bullet = GetCurrentMagazine()[^1];

                    LineRenderer lineRenderer = bullet.GetComponent<LineRenderer>();
                    lineRenderer.SetPosition(0, firePoint.position);
                    lineRenderer.SetPosition(1, firePoint.position + Quaternion.Euler(0f, 0f, angle) * transform.right * shootingDirection);

                    //lineRenderer.material.color = Color.red;
                    //lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

                    //lineRenderer.endColor = Color.red;
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    yield return new WaitForSeconds(lnOnFor);
                    lineRenderer.startWidth = 0f;
                    lineRenderer.endWidth = 0f;

                }
            }







            Debug.Log("ss");


            //List<float> angles = new List<float> { UnityEngine.Random.Range(45, 91), UnityEngine.Random.Range(-45, 46), UnityEngine.Random.Range(-90, -44) };

            //foreach (float angle in angles)
            //{
            //    for (int i = 0; i < 2; i++)
            //    {
            //        RaycastHit2D[] bulletHits = Physics2D.RaycastAll(firePoint.position, shootingVector * angle, shootingDirection);
            //        foreach (RaycastHit2D hit in bulletHits)
            //        {
            //            if (hit.transform.CompareTag("Enemy"))
            //            {
            //                hit.transform.GetComponent<EnemyStateManager>().GetAmountofDamage(currentWeapon.GetWeaponDamage());
            //                hit.transform.GetComponent<EnemyStateManager>().SwitchState(hit.transform.GetComponent<EnemyStateManager>().TakeDamageState);
            //            }
            //        }

            //        LineRenderer lineRenderer = bullet.GetComponent<LineRenderer>();
            //        if (lineRenderer == null) Debug.LogError("LineRenderer is null");
            //        lineRenderer.SetPositions(new Vector3[] { firePoint.position, firePoint.position + Vector3.right * shootingDirection });
            //        lineRenderer.startWidth = 0.1f;
            //        lineRenderer.endWidth = 0.1f;
            //        yield return new WaitForSeconds(lnOnFor);
            //        lineRenderer.startWidth = 0f;
            //        lineRenderer.endWidth = 0f;
            //    }
        }

    }

    private void HitWithTheWeapon()
    {
        ShakeCamera(currentWeapon.GetShakeIntensity(), .1f);
        shootingVector = transform.right;
        sinceLastShoot = 0;

        RaycastHit2D[] hits = Physics2D.RaycastAll(firePoint.position, shootingVector, shootingDirection);
        GameObject hittedEnemy = hits.Where(hit => hit.collider.CompareTag("Enemy")).Select(hit => hit.collider.gameObject).FirstOrDefault();

        if (hittedEnemy != null)
        {
            //GetComponent<AudioSource>().volume = 0.1f;
            //GetComponent<AudioSource>().PlayOneShot(closeHit);

            EnemyStateManager enemyStateManager = hittedEnemy.transform.GetComponent<EnemyStateManager>();
            enemyStateManager.GetAmountofDamage(currentWeapon.GetWeaponDamage());
            enemyStateManager.SwitchState(enemyStateManager.TakeDamageState);
        }

    }


    public void ShakeCamera(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = timer;
    }

    public List<GameObject> GetCurrentMagazine()
    {
        return currentWeapon.GetCurrentMagazine();
    }

    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }
    public void ResetCurrentMagazine()
    {
        currentWeapon.ResetCurrentMagazine();
    }







}