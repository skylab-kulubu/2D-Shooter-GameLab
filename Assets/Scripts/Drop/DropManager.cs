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
    [SerializeField] private GameObject fenceWeapon;

    public void DropSomething()
    {
        if (droppedAmount > 0) return;
        
        GameObject dropItem = RandomDropFormula();
        Instantiate(dropItem, gameObject.transform.position, Quaternion.identity);

        droppedAmount++;
    }

    public GameObject RandomDropFormula()
    {
        int randomNumber = UnityEngine.Random.Range(0, 101);
        if(randomNumber < 10)
        {
            int randomNumber2 = UnityEngine.Random.Range(1, 4);
            if(randomNumber2 == 1)
            {
                return fenceWeapon;
            }
            else
            {
                return diamond;
            }
        }
        else if (randomNumber < 35)
        {
            return rock;
        }
        else
        {
            int randomNumber3 = UnityEngine.Random.Range(1, 7);
            if(randomNumber3 == 1 || randomNumber3 == 2 || randomNumber3 == 3)
            {
                return wood;
            }
            else if (randomNumber3 == 4 || randomNumber3 == 5)
            {
                return ammo;
            }
            else
            {
                return health;
            }
        }
    }

}
