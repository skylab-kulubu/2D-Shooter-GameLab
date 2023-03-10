using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FenceUpgradeController : MonoBehaviour
{
    [SerializeField] private FenceMaterial currentMaterial;
    [SerializeField] private List<FenceMaterial> sumMaterials = new List<FenceMaterial>();
    [SerializeField] private int numberOfCurrentMaterial = 0;
    [SerializeField] private GameObject upgradePanel;

    [Header("Upgrade")]
    [SerializeField] private Text requiredMaterialToUpgradeText;
    [SerializeField] private Text requiredMaterialToUpgradeAmountText;
    [SerializeField] private Image materialUpgradeIcon;

    [Header("Repair")]
    [SerializeField] private Text requiredMaterialToFixText;
    [SerializeField] private Text requiredMaterialToFixAmountText;
    [SerializeField] private Image materialFixIcon;




    private void Start()
    {
        currentMaterial = GetComponent<FenceController>().GetCurrentFenceMaterial();
    }

    private void Update()
    {
        
    }

    public void AddMaterial(FenceMaterial fenceMaterial)
    {
        if(fenceMaterial.name == currentMaterial.name)
        {
            sumMaterials.Add(fenceMaterial);
            numberOfCurrentMaterial++;
        }
    }

    public void ResetAll()
    {
        numberOfCurrentMaterial = 0;
        sumMaterials.Clear();
    }
    public GameObject GetUpgradePanel()
    {
        return upgradePanel;
    }


}
