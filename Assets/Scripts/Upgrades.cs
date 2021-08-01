using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int UpgradeID;
    public Image UpgradeButton;
    public Image UpgradeAllButton;
    public TMP_Text LevelText;
    public TMP_Text DescriptionText;
    public TMP_Text CostText;
    public void BuyClickUpgrade()=> UpgradesManager.instance.BuyClickUpgrade(UpgradeID);
    public void BuyAllClickUpgrade() => UpgradesManager.instance.BuyAllClickUpgrade(UpgradeID);
    public void BuyIdleUpgrade() => UpgradesManager.instance.BuyIdleUpgrade(UpgradeID);
    public void BuyAllIdleUpgrade() => UpgradesManager.instance.BuyAllIdleUpgrade(UpgradeID);
    public void BuyUpgradeUpgrade() => UpgradesManager.instance.BuyUpgradeUpgrade(UpgradeID);
    public void BuyAllUpgradeUpgrade() => UpgradesManager.instance.BuyAllUpgradeUpgrade(UpgradeID);
    public void BuyClickPercentageUpgrade() => UpgradesManager.instance.BuyClickPercentageUpgrade(UpgradeID);
    public void BuyIdlePercentageUpgrade() => UpgradesManager.instance.BuyIdlePercentageUpgrade(UpgradeID);
    public void BuyAllClickPercentageUpgrade() => UpgradesManager.instance.BuyAllClickPercentageUpgrade(UpgradeID);
    public void BuyAllIdlePercentageUpgrade() => UpgradesManager.instance.BuyAllIdlePercentageUpgrade(UpgradeID);
}
