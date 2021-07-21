using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    public List<Upgrades> clickUpgrades;
    public List<Upgrades> idleUpgrades;

    //Click
    public Upgrades clickUpgradePrefab;
    public ScrollRect clickUpgradesScroll;
    public Transform clickUpgradesPanel;
    public string[] clickUpgradeNames;
    public double[] clickUpgradeBaseCost;
    public double[] clickUpgradeCostMult;
    public double[] clickUpgradeBasePower;

    //Idle
    public Upgrades idleUpgradePrefab;
    public ScrollRect idleUpgradesScroll;
    public Transform idleUpgradesPanel;
    public string[] idleUpgradeNames;
    public double[] idleUpgradeBaseCost;
    public double[] idleUpgradeCostMult;
    public double[] idleUpgradeBasePower;


    public void Awake() => instance = this;

    public void StartUpgradeManager()
    {
        //Click
        clickUpgradeBaseCost = new double[] { 10, 50, 100, 500, 1000, 5000 };
        clickUpgradeBasePower = new double[] { 1, 5, 10, 50, 100, 500};
        clickUpgradeCostMult = new double[] { 1.2, 1.3, 1.4, 1.5, 1.6, 1.7 };
        clickUpgradeNames = new[] { "+1 $ per click ", "+5 $ per click ", "+10 $ per click","+50 $ per click ", "+100 $ per click ", "+500 $ per click  " };
        for (int i = 0; i < Controller.instance.data.clickUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel);
            upgrade.UpgradeID = i;
            clickUpgrades.Add(upgrade);
        }
        clickUpgradesScroll.normalizedPosition = new Vector2(0, 0);

        //Idle
        idleUpgradeBaseCost = new double[] { 20, 100, 200, 1000, 2000, 10000};
        idleUpgradeBasePower = new double[] { 0.5, 2.5, 5, 25, 125, 250};
        idleUpgradeCostMult = new double[] { 1.4, 1.6, 1.8, 2, 2.2, 2.4};
        idleUpgradeNames = new[] { "+0,5 $ per second", "+2,5 $ per second", "+5 $ per second", "+25 $ per second", "+125 $ per second", "+250 $ per second" };
        for (int i = 0; i< Controller.instance.data.idleUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(idleUpgradePrefab, idleUpgradesPanel);
            upgrade.UpgradeID = i;
            idleUpgrades.Add(upgrade);
        }
        idleUpgradesScroll.normalizedPosition = new Vector2(0, 0);


        updateClickUpgradeUI();
        updateIdleUpgradeUI();
    }
    public void updateClickUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < clickUpgrades.Count; i++) UpdateClickUI(i);
            
            
        else UpdateClickUI(UpgradeID);

        void UpdateClickUI(int ID)
        {
            clickUpgrades[ID].LevelText.text = $"{data.clickUpgradeLevel[ID].ToString()}";
            clickUpgrades[ID].CostText.text = $"Cost: $ {ClickUpgradeCost(ID)}";
            clickUpgrades[ID].DescriptionText.text = $"{clickUpgradeNames[ID]}";
        }
    }
    public void updateIdleUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < idleUpgrades.Count; i++) UpdateIdleUI(i);
        else UpdateIdleUI(UpgradeID);
        void UpdateIdleUI(int ID)
        {
            idleUpgrades[ID].LevelText.text = $"{data.idleUpgradeLevel[ID].ToString()}";
            idleUpgrades[ID].CostText.text = $"Cost: $ {IdleUpgradeCost(ID)}";
            idleUpgrades[ID].DescriptionText.text = $"{idleUpgradeNames[ID]}";
        }

    }

    public double IdleUpgradeCost(int UpgradeID) => Math.Round(idleUpgradeBaseCost[UpgradeID] * Math.Pow(idleUpgradeCostMult[UpgradeID], Controller.instance.data.idleUpgradeLevel[UpgradeID]));

    public double ClickUpgradeCost(int UpgradeID) => Math.Round(clickUpgradeBaseCost[UpgradeID] * Math.Pow(clickUpgradeCostMult[UpgradeID], Controller.instance.data.clickUpgradeLevel[UpgradeID]) );
    
    public void BuyClickUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        if (data.dollars >= ClickUpgradeCost(UpgradeID))
        {
            data.dollars -= ClickUpgradeCost(UpgradeID);
            data.clickUpgradeLevel[UpgradeID] += 1;
            updateClickUpgradeUI(UpgradeID);
        }
    }
    public void BuyIdleUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        if (data.dollars >= IdleUpgradeCost(UpgradeID))
        {
            data.dollars -= IdleUpgradeCost(UpgradeID);
            data.idleUpgradeLevel[UpgradeID] += 1;
            updateIdleUpgradeUI(UpgradeID);

        }
    }
}
