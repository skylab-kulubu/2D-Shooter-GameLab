using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceWeaponPickup : MonoBehaviour
{
    [SerializeField] private float activeTime = 30;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EditFence>().SetHasWeapon(true);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        activeTime -= Time.deltaTime;
        if (activeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
