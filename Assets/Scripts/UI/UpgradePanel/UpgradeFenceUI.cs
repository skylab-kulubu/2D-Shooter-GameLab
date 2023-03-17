using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFenceUI : MonoBehaviour
{
    private void OnMouseDown()
    {

        FenceUpgradeController[] objects = FindObjectsOfType<FenceUpgradeController>();
        string gameObj = gameObject.transform.parent.transform.parent.name;
        char lastChar = gameObj[gameObj.Length - 1];
        foreach (FenceUpgradeController obj in objects)
        {
            
            if (obj.GetFenceNumber().ToString() == lastChar.ToString())
            {
                int currentMaterialNumber = obj.GetComponent<FenceController>().GetCurrentFenceMaterial().GetFenceMaterialNumber();
                int requiredMaterialForUpgrade = obj.GetComponent<FenceController>().GetCurrentFence().GetNextFence().GetRequiredMaterialToUpgrade();

                int playersAmountofMaterialForNextFence = FindObjectOfType<EditFence>().ReturnRequiredFenceMaterial(currentMaterialNumber + 1);

                print("currentMaterialNumber: " + currentMaterialNumber);
                print("requiredMaterialForUpgrade: " + requiredMaterialForUpgrade);
                print("playersAmountofMaterialForNextFence: " + playersAmountofMaterialForNextFence);

                if(playersAmountofMaterialForNextFence >= requiredMaterialForUpgrade)
                {
                    obj.GetComponent<FenceController>().ChangeTheFence(obj.GetComponent<FenceController>().GetCurrentFence().GetNextFence());
                }
                else
                {
                    Debug.Log($"not enough {obj.GetComponent<FenceController>().GetCurrentFence().GetNextFence().GetFenceMaterial()}");

                }
            }
        }

    }

}
