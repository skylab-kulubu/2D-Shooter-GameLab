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

                if (playersAmountofMaterialForNextFence >= requiredMaterialForUpgrade)
                {
                    Debug.Log("Fence is Changed");
                    Fence nextFence = fence.GetComponent<FenceController>().GetCurrentFence().GetNextFence();
                    int fenceMaterialNumber = fence.GetComponent<FenceController>().GetCurrentFenceMaterial().GetFenceMaterialNumber();

                    fence.GetComponent<FenceController>().ChangeTheFence(nextFence);
                    fence.GetComponent<FenceController>().SetCurrentFence(nextFence);

                    int fixAmount = nextFence.GetRequiredMaterialToFix();
                    SpriteRenderer currentFenceSprite = nextFence.GetFenceMaterial().GetFenceMaterialSpriteRenderer();
                    transform.parent.parent.GetComponent<MaterialIconChanger>().FixAmount = fixAmount;
                    transform.parent.parent.GetComponent<MaterialIconChanger>().FixIcon.color = currentFenceSprite.color;

                    FindObjectOfType<EditFence>().ReduceMaterialAmound(fenceMaterialNumber + 1, nextFence.GetRequiredMaterialToUpgrade());

                    if (nextFence.GetNextFence() == null)
                    {
                        transform.parent.parent.GetComponent<MaterialIconChanger>().UpgradePanel.SetActive(false);
                        return;
                    }
                        

                    SpriteRenderer nextFenceSprite = nextFence.GetNextFence().GetFenceMaterial().GetFenceMaterialSpriteRenderer();
                    int upgradeAmount = nextFence.GetNextFence().GetRequiredMaterialToUpgrade();

                    transform.parent.parent.GetComponent<MaterialIconChanger>().UpgradeIcon.color = nextFenceSprite.color;
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
