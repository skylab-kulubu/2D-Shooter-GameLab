using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "BulletData/Make New BulletData", order = 0)]

public class BulletData : ScriptableObject
{
    [SerializeField] private List<Weapon> weapons;

    [SerializeField] private int pistolBulletAmount = 0;
    [SerializeField] private int shotgunBulletAmount = 0;
    [SerializeField] private int rifleBulletAmount = 0;

    public List<Weapon> Weapons { get { return weapons; } }
    public int PistolBulletAmount { get { return pistolBulletAmount; } set { pistolBulletAmount = value; }  }
    public int ShotgunBulletAmount { get { return shotgunBulletAmount; } set { shotgunBulletAmount = value; }  }
    public int RifleBulletAmount { get { return rifleBulletAmount; } set { rifleBulletAmount = value; } }



}
