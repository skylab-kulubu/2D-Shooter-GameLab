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
            FindObjectOfType<Shooting>().ResetCurrentMagazine();
            FindObjectOfType<Shooting>().EquipWeapon(weapons[index]);
            index++;
        }
        else
        {
            FindObjectOfType<Shooting>().ResetCurrentMagazine();
            FindObjectOfType<Shooting>().EquipWeapon(weapons[index]);
            FindObjectOfType<Shooting>().LoadMagazine(FindObjectOfType<Shooting>().GetCurrentMagazine(), FindObjectOfType<Shooting>().GetCurrentWeapon().GetMagazineCapacity());
            index++;

        }

    }

    public void PickUpKnife()
    {
        FindObjectOfType<Shooting>().ResetCurrentMagazine();
        FindObjectOfType<Shooting>().EquipWeapon(weapons[0]);

    }
    public void PickUpBat()
    {
        FindObjectOfType<Shooting>().ResetCurrentMagazine();
        FindObjectOfType<Shooting>().EquipWeapon(weapons[1]);

    }
    public void PickUpPistol()
    {
        FindObjectOfType<Shooting>().ResetCurrentMagazine();
        FindObjectOfType<Shooting>().EquipWeapon(weapons[2]);
        FindObjectOfType<Shooting>().LoadMagazine(FindObjectOfType<Shooting>().GetCurrentMagazine(), FindObjectOfType<Shooting>().BulletData.PistolBulletAmount);



    }
    public void PickUpShotgun()
    {
        FindObjectOfType<Shooting>().ResetCurrentMagazine();
        FindObjectOfType<Shooting>().EquipWeapon(weapons[3]);
        FindObjectOfType<Shooting>().LoadMagazine(FindObjectOfType<Shooting>().GetCurrentMagazine(), FindObjectOfType<Shooting>().BulletData.ShotgunBulletAmount);


    }
    public void PickUpRifle()
    {
        FindObjectOfType<Shooting>().ResetCurrentMagazine();
        FindObjectOfType<Shooting>().EquipWeapon(weapons[4]);
        FindObjectOfType<Shooting>().LoadMagazine(FindObjectOfType<Shooting>().GetCurrentMagazine(), FindObjectOfType<Shooting>().BulletData.RifleBulletAmount);


    }

}
