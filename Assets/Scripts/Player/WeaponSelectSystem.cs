using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectSystem : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    private int index = 0;
    public void EquipNextWeapon()
    {
        if (index == weapons.Count) index = 0;
        if (weapons[index].GetIsInFighting())
        {
            FindObjectOfType<Shooting>().EquipWeapon(weapons[index]);
            index++;
        }
        else
        {
            FindObjectOfType<Shooting>().EquipWeapon(weapons[index]);
            FindObjectOfType<Shooting>().ResetCurrentMagazine();
            FindObjectOfType<Shooting>().LoadMagazine(FindObjectOfType<Shooting>().GetCurrentMagazine(), FindObjectOfType<Shooting>().GetCurrentWeapon().GetMagazineCapacity());
            index++;

        }

    }
}
