using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float shootingDistance = 100f;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float lnOnFor = 0.1f;



    private void OnFire() 
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {

        Vector2 shootingDirection = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, shootingDirection, shootingDistance);
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
        
        lineRenderer.SetPosition(1, firePoint.transform.position + firePoint.transform.right * shootingDistance);

        yield return new WaitForSeconds(lnOnFor);
        lineRenderer.startWidth = 0f;
        lineRenderer.endWidth = 0f;

    } 
}
