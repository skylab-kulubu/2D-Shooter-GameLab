using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialIconChanger : MonoBehaviour
{
    [SerializeField] private Image _upgradeIcon;
    [SerializeField] private Image _fixIcon;

    [SerializeField] private int _requiredMaterialAmountUpgrade = 15;
    [SerializeField] private int _requiredMaterialAmountFix = 10;

    [SerializeField] private Text _requiredMaterialAmountUpgradeText;
    [SerializeField] private Text _requiredMaterialAmountFixText;
    public Image UpgradeIcon { get { return _upgradeIcon; } set { _upgradeIcon = value; } }
    public Image FixIcon { get { return _fixIcon; } set { _fixIcon = value; } }
    public int UpgradeAmount { get { return _requiredMaterialAmountUpgrade; } set { _requiredMaterialAmountUpgrade = value; } }
    public int FixAmount { get { return _requiredMaterialAmountFix; } set { _requiredMaterialAmountFix = value; } }

    private void Update()
    {
        _requiredMaterialAmountUpgradeText.text = "X" + UpgradeAmount.ToString();
        _requiredMaterialAmountFixText.text = "X" + FixAmount.ToString();
    }
}
