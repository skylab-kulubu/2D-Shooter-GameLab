using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFenceUI : MonoBehaviour
{
    private void OnMouseDown()
    {

        FenceUpgradeController[] fences = FindObjectsOfType<FenceUpgradeController>();
        string gameObj = gameObject.transform.parent.transform.parent.name;
        char lastChar = gameObj[gameObj.Length - 1];
        foreach (FenceUpgradeController fence in fences)
        {
            
            if (fence.GetFenceNumber().ToString() == lastChar.ToString())
            {
                int currentMaterialNumber = fence.GetComponent<FenceController>().GetCurrentFenceMaterial().GetFenceMaterialNumber();
                int requiredMaterialForUpgrade = fence.GetComponent<FenceController>().GetCurrentFence().GetNextFence().GetRequiredMaterialToUpgrade();

                int playersAmountofMaterialForNextFence = FindObjectOfType<EditFence>().ReturnRequiredFenceMaterial(currentMaterialNumber + 1);

                print("currentMaterialNumber: " + currentMaterialNumber);
                print("requiredMaterialForUpgrade: " + requiredMaterialForUpgrade);
                print("playersAmountofMaterialForNextFence: " + playersAmountofMaterialForNextFence);

                if(playersAmountofMaterialForNextFence >= requiredMaterialForUpgrade)
                {
                    Debug.Log("Fence is Changed");
                    Fence nextFence = fence.GetComponent<FenceController>().GetCurrentFence().GetNextFence();
                    fence.GetComponent<FenceController>().ChangeTheFence(nextFence);
                    fence.GetComponent<FenceController>().SetCurrentFence(nextFence);

                    int fixAmount = nextFence.GetRequiredMaterialToFix();
                    transform.parent.parent.GetComponent<MaterialIconChanger>().FixAmount = fixAmount;
                    if (nextFence.GetNextFence() == null) return;

                    Sprite fenceMaterialIcon = nextFence.GetNextFence().GetFenceMaterial().GetFenceMaterialIcon();
                    int upgradeAmount = nextFence.GetNextFence().GetRequiredMaterialToUpgrade();

                    transform.parent.parent.GetComponent<MaterialIconChanger>().UpgradeIcon.sprite = fenceMaterialIcon;
                    transform.parent.parent.GetComponent<MaterialIconChanger>().FixIcon.sprite = fenceMaterialIcon;
                    transform.parent.parent.GetComponent<MaterialIconChanger>().UpgradeAmount = upgradeAmount;
                }
                else
                {
                    Debug.Log($"not enough {fence.GetComponent<FenceController>().GetCurrentFence().GetNextFence().GetFenceMaterial()}");

                }


            }
        }

    }

}
