using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> drops = new List<GameObject>();
    int droppedAmount = 0;
    [Header("Gameobjects")]
    [SerializeField] private GameObject diamond;
    [SerializeField] private GameObject wood;
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject ammo;

    public void DropSomething()
    {
        if (droppedAmount > 0) return;
        
        GameObject dropItem = drops[RandomDropFormula()];

        Instantiate(dropItem, gameObject.transform.position, Quaternion.identity);

        droppedAmount++;
    }

    public int RandomDropFormula()
    {
        int ammoRandomNum = UnityEngine.Random.Range(0, 100);
        if (ammoRandomNum < 60 && drops.Contains(ammo))
        {
            return drops.IndexOf(ammo);
        }

        int randomNum = UnityEngine.Random.Range(0, 100);
        if (randomNum < 10 && drops.Contains(diamond))
        {
            return drops.IndexOf(diamond);
        }
        else if (randomNum < 45 && drops.Contains(wood))
        {
            return drops.IndexOf(wood);
        }
        else if (randomNum < 70 && drops.Contains(rock))
        {
            return drops.IndexOf(rock);
        }
        else if (randomNum < 95 && drops.Contains(health))
        {
            return drops.IndexOf(health);
        }
        else if (randomNum < 100 && drops.Contains(ammo))
        {
            return drops.IndexOf(ammo);
        }
        else
        {
            return -1;
        }
    }
}
