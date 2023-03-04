using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            List<GameObject> magazine = collision.gameObject.GetComponent<Shooting>().GetCurrentMagazine();
            Weapon weapon = collision.gameObject.GetComponent<Shooting>().GetCurrentWeapon();
            collision.gameObject.GetComponent<Shooting>().LoadMagazine(magazine, weapon.GetMagazineCapacity());
            Destroy(gameObject);
        }
    }
}
