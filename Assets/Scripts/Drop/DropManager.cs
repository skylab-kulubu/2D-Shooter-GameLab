using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    List<GameObject> drops = new List<GameObject>();
    

    public void DropSomething()
    {
        int randomItemNumber = UnityEngine.Random.Range(0, drops.Count);
        GameObject dropItem = drops[randomItemNumber];

        Instantiate(dropItem, gameObject.transform.position, Quaternion.identity);
    }
}
