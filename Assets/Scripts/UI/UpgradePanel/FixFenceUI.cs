using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixFenceUI : MonoBehaviour
{
    private void OnMouseDown()
    {
        int fenceMaterialNumber;

        FenceUpgradeController[] objects = FindObjectsOfType<FenceUpgradeController>();
        string gameObj = gameObject.transform.parent.transform.parent.name;
        char lastChar = gameObj[gameObj.Length - 1];
        foreach (FenceUpgradeController obj in objects)
        {

            if (obj.GetFenceNumber().ToString() == lastChar.ToString())
            {
                




                fenceMaterialNumber = obj.GetComponent<FenceController>().GetCurrentFenceMaterial().GetFenceMaterialNumber();
                int playersAmountofMaterialNumber = FindObjectOfType<EditFence>().ReturnRequiredFenceMaterial(fenceMaterialNumber);
                print("fenceMaterialNumber: " + fenceMaterialNumber);
                print("playersAmountofMaterialNumber: " + playersAmountofMaterialNumber);

                if(obj.GetComponent<FenceController>().GetFenceHealth() == obj.GetComponent<FenceController>().GetCurrentFence().GetFenceHealthPoints())
                {
                    print("health is full"); return;
                }
                if (playersAmountofMaterialNumber >= obj.GetComponent<FenceController>().GetCurrentFence().GetRequiredMaterialToFix())
                {
                    obj.GetComponent<FenceController>().SetFenceHealth(obj.GetComponent<FenceController>().GetCurrentFence().GetFenceHealthPoints());
                    FindObjectOfType<EditFence>().ReduceMaterialAmound(fenceMaterialNumber, obj.GetComponent<FenceController>().GetCurrentFence().GetRequiredMaterialToFix());
                }
                else
                {
                    Debug.Log($"not enough {obj.GetComponent<FenceController>().GetCurrentFenceMaterial()}");
                }

            }
        }

    }
}
