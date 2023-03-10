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

    [SerializeField] private GameObject currentUpgradePanel;

    [SerializeField] private Transform upgradePanelHolder;

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
        currentUpgradePanel = Instantiate(GetUpgradePanel(), transform.position, Quaternion.identity, upgradePanelHolder);
        currentUpgradePanel.SetActive(false);

    }

    private void Update()
    {
        requiredMaterialToUpgradeAmountText.text = GetComponent<FenceController>().GetCurrentFence().GetNextFence().GetRequiredMaterialToUpgrade().ToString();
        materialUpgradeIcon.sprite = GetComponent<FenceController>().GetCurrentFence().GetNextFence().GetFenceMaterial().GetFenceMaterialIcon();
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

    public GameObject GetCurrentUpgradePanel()
    {
        return currentUpgradePanel;
    }


}
