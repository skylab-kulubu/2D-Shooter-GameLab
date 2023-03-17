using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditFence : MonoBehaviour
{
    [SerializeField] private int woodAmount = 0;
    [SerializeField] private int rockAmount = 0;
    [SerializeField] private int diamondAmount = 0;

    [SerializeField] private bool hasFenceWeapon = false;

    

    private bool isPanelOpen = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            collision.gameObject.GetComponent<FenceUpgradeController>().GetCurrentUpgradePanel().SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            collision.gameObject.GetComponent<FenceUpgradeController>().GetCurrentUpgradePanel().SetActive(false);
        }
    }

    internal int ReturnRequiredFenceMaterial(int fenceMaterialNumber)
    {
        if(fenceMaterialNumber == 1)
        {
            return woodAmount;
        }
        else if (fenceMaterialNumber == 2)
        {
            return rockAmount;
        }
        else if (fenceMaterialNumber == 3)
        {
            return diamondAmount;
        }
        return 0;
    }

    public bool GetIsPanelpen()
    {
        return isPanelOpen;
    }

    public void PickUpMaterial(int fenceMaterialNumber)
    {
        if(fenceMaterialNumber == 1)
        {
            woodAmount++;
        }
        else if(fenceMaterialNumber == 2)
        {
            rockAmount++;
        }
        else if (fenceMaterialNumber == 3)
        {
            diamondAmount++;
        }
    }

    public int GetWoodMaterial()
    {
        return woodAmount;
    }

    public int GetRockMaterial()
    {
        return rockAmount;
    }
    public int GetDiamondMaterial()
    {
        return diamondAmount;
    }

    public void ReduceMaterialAmound(int fenceMaterialNumber, int amount)
    {
        if (fenceMaterialNumber == 1)
        {
            woodAmount -= amount;
        }
        else if (fenceMaterialNumber == 2)
        {
            rockAmount -= amount;
        }
        else if (fenceMaterialNumber == 3)
        {
            diamondAmount -= amount;
        }
    }

    public bool GetHasFenceWeapon()
    {
        return hasFenceWeapon;
    }
    public void SetHasWeapon(bool trueOrFalse)
    {
        hasFenceWeapon = trueOrFalse;
    }
    

    

}
