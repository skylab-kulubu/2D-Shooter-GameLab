using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceWeapon : MonoBehaviour
{
    private float sinceLastShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        sinceLastShoot += Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 10, 1 << LayerMask.NameToLayer("Enemy"));
        if (hit.collider != null)
        {

            StartCoroutine(Shoot(hit.collider.gameObject));
        }
    }

    private IEnumerator Shoot(GameObject target)
    {
        if (sinceLastShoot < 2) yield break;
        sinceLastShoot = 0;

        EnemyStateManager enemyStateManager = target.transform.GetComponent<EnemyStateManager>();
        enemyStateManager.GetAmountofDamage(40);
        enemyStateManager.SwitchState(enemyStateManager.TakeDamageState);

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null) Debug.LogError("LineRenderer is null");
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position * Vector2.left * 100);

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        yield return new WaitForSeconds(0.1f);
        lineRenderer.startWidth = 0f;
        lineRenderer.endWidth = 0f;
    }
}
