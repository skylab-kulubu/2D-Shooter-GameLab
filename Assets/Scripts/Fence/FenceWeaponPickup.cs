using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceWeaponPickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EditFence>().SetHasWeapon(true);
            Destroy(gameObject);
        }
    }
}
