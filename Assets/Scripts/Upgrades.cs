using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int UpgradeID;
    public string UpgradeType;
    public Image UpgradeButton;
    public Image UpgradeAllButton;
    public TMP_Text LevelText;
    public TMP_Text DescriptionText;
    public TMP_Text CostText;
    public void BuyUpgrade()=> UpgradesManager.instance.BuyUpgrade(UpgradeID,UpgradeType);
    public void BuyAllUpgrade() => UpgradesManager.instance.BuyAllUpgrade(UpgradeID,UpgradeType);

}
