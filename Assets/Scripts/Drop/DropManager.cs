using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> drops = new List<GameObject>();
    int droppedAmount = 0;

    public void DropSomething()
    {
        if (droppedAmount > 0) return;
        int randomItemNumber = UnityEngine.Random.Range(0, drops.Count + drops.Count);
        if (randomItemNumber >= drops.Count) return;
        GameObject dropItem = drops[randomItemNumber];

        Instantiate(dropItem, gameObject.transform.position, Quaternion.identity);

        droppedAmount++;
    }
}
