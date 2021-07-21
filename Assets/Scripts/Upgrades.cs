using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int UpgradeID;
    public Image UpgradeButton;
    public TMP_Text LevelText;
    public TMP_Text DescriptionText;
    public TMP_Text CostText;
    public void BuyClickUpgrade()=> UpgradesManager.instance.BuyClickUpgrade(UpgradeID);
    public void BuyIdleUpgrade() => UpgradesManager.instance.BuyIdleUpgrade(UpgradeID);
}
