using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Shooting : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private float lnOnFor = 0.1f;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private float shakeTimer = 0;

    [SerializeField] Transform weaponMainTransform;
    [SerializeField] Weapon weapon = null;

    

    private void Start()
    {
        SpawnWeapon();
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
    }

    private void SpawnWeapon()
    {
        if (weapon == null) return;
        weapon.Spawn(weaponMainTransform);
    }

    private void Update()
    {
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
    }
    private void OnFire() 
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        ShakeCamera(weapon.GetShakeIntensity(), .1f);
        Vector2 shootingDirection = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, shootingDirection, weapon.GetWeaponRange());
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;


        if (hit.collider != null)
        {
            // Hit something
            Debug.Log("Hit " + hit.collider.name);
        }
        else
        {
            // Did not hit anything
            Debug.Log("Missed");
        }
        
        lineRenderer.SetPosition(1, firePoint.transform.position + firePoint.transform.right * weapon.GetWeaponRange());

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
