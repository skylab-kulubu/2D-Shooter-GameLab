using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private float activeTime = 30;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            float maxHealth = collision.gameObject.GetComponent<PlayerHealth>().GetMaxPlayerHealth();
            float currentHealth = collision.gameObject.GetComponent<PlayerHealth>().GetPlayerHealthPoints();
            if (currentHealth >= maxHealth) return;
            collision.gameObject.GetComponent<PlayerHealth>().AddPlayerHealthPoints(Mathf.Min(maxHealth - currentHealth, 50));
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        activeTime -= Time.deltaTime;
        if(activeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
