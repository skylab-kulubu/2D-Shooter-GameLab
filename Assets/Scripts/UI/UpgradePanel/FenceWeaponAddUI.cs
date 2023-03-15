using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceWeaponAddUI : MonoBehaviour
{
    private void OnMouseDown()
    {
        SetWeaponToFence();
    }
    public void SetWeaponToFence()
    {
        if (!FindObjectOfType<EditFence>().GetHasFenceWeapon()) return;

        FenceUpgradeController[] objects = FindObjectsOfType<FenceUpgradeController>();
        string gameObj = gameObject.transform.parent.transform.parent.name;
        char lastChar = gameObj[gameObj.Length - 1];
        foreach (FenceUpgradeController obj in objects)
        {
            Debug.Log("fencenumber: "+ obj.GetFenceNumber());
            Debug.Log("lastchar: "+ lastChar.ToString());
            if (obj.GetFenceNumber().ToString() == lastChar.ToString())
            {
                Debug.Log("nasý yoð");
                obj.GetComponent<FenceWeapon>().enabled = true;
                obj.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
            
        FindObjectOfType<EditFence>().SetHasWeapon(false);
    }
}
