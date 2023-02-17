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

    private bool isLookingRight = true;

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
            StartCoroutine(Shoot());
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
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, shootingVector, shootingDirection);
        


        if (hit.collider != null)
        {
            if(hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyStateManager>().GetAmountofDamage(currentWeapon.GetWeaponDamage());
                Debug.Log(hit.transform.GetComponent<EnemyStateManager>().currentHealthPoints);
                hit.transform.GetComponent<EnemyStateManager>().SwitchState(hit.transform.GetComponent<EnemyStateManager>().TakeDamageState);
            }
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
    
    public void ShakeCamera(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = timer;
    }

    

    
}