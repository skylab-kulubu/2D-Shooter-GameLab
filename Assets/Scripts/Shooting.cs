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
        ShakeCamera(currentWeapon.GetShakeIntensity(), .1f);
        Vector2 shootingDirection = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(currentWeapon.GetFirePoint(), shootingDirection, currentWeapon.GetWeaponRange());
        


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

        if (currentWeapon.GetIsInFighting()) yield break;

        lineRenderer.SetPosition(0, currentWeapon.GetFirePoint());
        print(currentWeapon.GetFirePoint());
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.SetPosition(1, ((currentWeapon.GetFirePoint() + currentWeapon.GetFirePoint()) + Vector3.right) * currentWeapon.GetWeaponRange());

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
