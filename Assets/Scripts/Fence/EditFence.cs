using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditFence : MonoBehaviour
{
    [SerializeField] private int woodAmount = 0;
    [SerializeField] private int rockAmount = 0;
    [SerializeField] private int diamondAmount = 0;

    

    private bool panelIsOpen = false;
    
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


    public bool GetPanelIsOpen()
    {
        return panelIsOpen;
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
}
