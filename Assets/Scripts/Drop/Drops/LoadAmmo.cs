using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAmmo : MonoBehaviour
{
    [SerializeField] private float activeTime = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            List<GameObject> magazine = collision.gameObject.GetComponent<Shooting>().GetCurrentMagazine();
            Weapon weapon = collision.gameObject.GetComponent<Shooting>().GetCurrentWeapon();
            if (magazine.Count >= weapon.GetMagazineCapacity()) return;
            collision.gameObject.GetComponent<Shooting>().LoadMagazine(magazine, weapon.GetMagazineCapacity());
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
