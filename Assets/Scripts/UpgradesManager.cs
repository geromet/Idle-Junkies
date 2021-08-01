using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    [SerializeField] Upgrades clickUpgradePrefab;
    [SerializeField] ScrollRect clickUpgradesScroll;
    [SerializeField] Transform clickUpgradesPanel;
    public List<string> clickUpgradeNames;
    public List<double> clickUpgradeBaseCost;
    public List<double> clickUpgradeCostMult;
    public List<double> clickUpgradeBasePower;
    public List<Upgrades> clickUpgrades;   
    [SerializeField] Upgrades idleUpgradePrefab;
    [SerializeField] ScrollRect idleUpgradesScroll;
    [SerializeField] Transform idleUpgradesPanel;
    public List<string> idleUpgradeNames;
    public List<double> idleUpgradeBaseCost;
    public List<double> idleUpgradeCostMult;
    public List<double> idleUpgradeBasePower;
    public List<Upgrades> idleUpgrades;    
    [SerializeField] Upgrades upgradeUpgradePrefab;
    [SerializeField] ScrollRect upgradeUpgradesScroll;
    [SerializeField] Transform upgradeUpgradesPanel;
    public List<string> upgradeUpgradeNames;
    public List<double> upgradeUpgradeBaseCost;
    public List<double> upgradeUpgradeCostMult;
    public List<double> upgradeUpgradeBasePower;
    public List<Upgrades> upgradeUpgrades;
    [SerializeField] Upgrades clickPercentageUpgradePrefab;
    [SerializeField] ScrollRect clickPercentageUpgradesScroll;
    [SerializeField] Transform clickPercentageUpgradesPanel;
    public List<string> clickPercentageUpgradeNames;
    public List<double> clickPercentageUpgradeBaseCost;
    public List<double> clickPercentageUpgradeCostMult;
    public List<double> clickPercentageUpgradeBasePower;
    public List<Upgrades> clickPercentageUpgrades;
    [SerializeField] Upgrades idlePercentageUpgradePrefab;
    [SerializeField] ScrollRect idlePercentageUpgradesScroll;
    [SerializeField] Transform idlePercentageUpgradesPanel;
    public List<string> idlePercentageUpgradeNames;
    public List<double> idlePercentageUpgradeBaseCost;
    public List<double> idlePercentageUpgradeCostMult;
    public List<double> idlePercentageUpgradeBasePower;
    public List<Upgrades> idlePercentageUpgrades;
    public void Awake() => instance = this;
    public void StartUpgradeManager()
    {
        InitializeBaseValues();
        clickUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        upgradeUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        idleUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        clickPercentageUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        idlePercentageUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        UpdateUpgradeUI();

    }

    private void InitializeBaseValues()
    {
        clickUpgradeBaseCost = new List<double>();
        clickUpgradeBasePower = new List<double>();
        clickUpgradeCostMult = new List<double>();
        clickUpgradeNames = new List<string>();
        idleUpgradeBaseCost = new List<double>();
        idleUpgradeBasePower = new List<double>();
        idleUpgradeCostMult = new List<double>();
        idleUpgradeNames = new List<string>();
        upgradeUpgradeBaseCost = new List<double>();
        upgradeUpgradeBasePower = new List<double>();
        upgradeUpgradeCostMult = new List<double>();
        upgradeUpgradeNames = new List<string>();
        clickPercentageUpgradeBaseCost = new List<double>();
        clickPercentageUpgradeBasePower = new List<double>();
        clickPercentageUpgradeCostMult = new List<double>();
        clickPercentageUpgradeNames = new List<string>();
        idlePercentageUpgradeBaseCost = new List<double>();
        idlePercentageUpgradeBasePower = new List<double>();
        idlePercentageUpgradeCostMult = new List<double>();
        idlePercentageUpgradeNames = new List<string>();
        clickUpgradeBaseCost.Add(10);
        clickUpgradeBasePower.Add(1);
        clickUpgradeCostMult.Add(1.1);
        idleUpgradeBaseCost.Add(20);
        idleUpgradeBasePower.Add(0.5);
        idleUpgradeCostMult.Add(1.1);
        upgradeUpgradeBaseCost.Add(40);
        upgradeUpgradeBasePower.Add(0.00001);
        upgradeUpgradeCostMult.Add(1.2);
        clickPercentageUpgradeBaseCost.Add(100);
        clickPercentageUpgradeBasePower.Add(0.5);
        clickPercentageUpgradeCostMult.Add(1.3);
        idlePercentageUpgradeBaseCost.Add(80);
        idlePercentageUpgradeBasePower.Add(0.4);
        idlePercentageUpgradeCostMult.Add(1.25);
        for (int i = 0; i < Controller.instance.data.clickUpgradeLevel.Count; i++)
            {
                if (i > 0)
                {
                    if (i % 2 == 0)
                    {
                        clickUpgradeBaseCost.Add((clickUpgradeBaseCost[i - 1] * 2));
                        clickUpgradeBasePower.Add((clickUpgradeBasePower[i - 1] * 2));
                    }
                    else
                    {
                        clickUpgradeBaseCost.Add(clickUpgradeBaseCost[i - 1] * 5);
                        clickUpgradeBasePower.Add(clickUpgradeBasePower[i - 1] * 5);
                    }
                    clickUpgradeCostMult.Add((clickUpgradeCostMult[i - 1] + 0.05));
                }
                clickUpgradeNames.Add("+ " + (Controller.instance.Symbolize((clickUpgradeBasePower[i])) + "$ / click"));
                Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel);
                upgrade.UpgradeID = i;
                clickUpgrades.Add(upgrade);
                
            }
        for (int i = 0; i < Controller.instance.data.idleUpgradeLevel.Count; i++)
            {
                if (i > 0)
                {
                    if (i % 2 == 0)
                    {
                        idleUpgradeBaseCost.Add((idleUpgradeBaseCost[i - 1] * 2));
                        idleUpgradeBasePower.Add(idleUpgradeBasePower[i - 1] * 2);
                    }
                    else
                    {
                        idleUpgradeBaseCost.Add(idleUpgradeBaseCost[i - 1] * 5);
                        idleUpgradeBasePower.Add(idleUpgradeBasePower[i - 1] * 5);
                    }
                    idleUpgradeCostMult.Add(idleUpgradeCostMult[i - 1] + 0.05);
                }
                idleUpgradeNames.Add("+ " + (Controller.instance.Symbolize(idleUpgradeBasePower[i])) + "$ / s");
                Upgrades upgrade = Instantiate(idleUpgradePrefab, idleUpgradesPanel);
                upgrade.UpgradeID = i;
                idleUpgrades.Add(upgrade);
                
            }
        for (int i = 0; i < Controller.instance.data.upgradeUpgradeLevel.Count; i++)
            {
                if (i > 0)
                {
                    if (i % 2 == 0)
                    {
                        upgradeUpgradeBaseCost.Add(upgradeUpgradeBaseCost[i - 1] * 2);
                        upgradeUpgradeBasePower.Add(upgradeUpgradeBasePower[i - 1] * 2);
                    }
                    else
                    {
                        upgradeUpgradeBaseCost.Add(upgradeUpgradeBaseCost[i - 1] * 4);
                        upgradeUpgradeBasePower.Add(upgradeUpgradeBasePower[i - 1] * 4);
                    }
                    upgradeUpgradeCostMult.Add(upgradeUpgradeCostMult[i - 1] + (i * 0.2));
                }
                upgradeUpgradeNames.Add("- " + (Controller.instance.Symbolize(upgradeUpgradeBasePower[i] * 100)) + "% cost");
                Upgrades upgrade = Instantiate(upgradeUpgradePrefab, upgradeUpgradesPanel);
                upgrade.UpgradeID = i;
                upgradeUpgrades.Add(upgrade);
            }
        for (int i = 0; i < Controller.instance.data.clickPercentageUpgradeLevel.Count; i++)
            {
                if (i > 0)
                {
                    if (i % 2 == 0)
                    {
                        clickPercentageUpgradeBaseCost.Add((clickPercentageUpgradeBaseCost[i - 1] * 2));
                        clickPercentageUpgradeBasePower.Add((clickPercentageUpgradeBasePower[i - 1] * 2));
                    }
                    else
                    {
                        clickPercentageUpgradeBaseCost.Add(clickPercentageUpgradeBaseCost[i - 1] * 5);
                        clickPercentageUpgradeBasePower.Add(clickPercentageUpgradeBasePower[i - 1] * 5);
                    }
                    clickPercentageUpgradeCostMult.Add((clickPercentageUpgradeCostMult[i - 1] + 0.05));
                }
                clickPercentageUpgradeNames.Add("+ " + (Controller.instance.Symbolize((clickPercentageUpgradeBasePower[i])) + "$ / click"));
                Upgrades upgrade = Instantiate(clickPercentageUpgradePrefab, clickPercentageUpgradesPanel);
                upgrade.UpgradeID = i;
                clickPercentageUpgrades.Add(upgrade);
            }
        for (int i = 0; i < Controller.instance.data.idlePercentageUpgradeLevel.Count; i++)
            {
                if (i > 0)
                {
                    if (i % 2 == 0)
                    {
                        idlePercentageUpgradeBaseCost.Add((idlePercentageUpgradeBaseCost[i - 1] * 2));
                        idlePercentageUpgradeBasePower.Add(idlePercentageUpgradeBasePower[i - 1] * 2);
                    }
                    else
                    {
                        idlePercentageUpgradeBaseCost.Add(idlePercentageUpgradeBaseCost[i - 1] * 5);
                        idlePercentageUpgradeBasePower.Add(idlePercentageUpgradeBasePower[i - 1] * 5);
                    }
                    idlePercentageUpgradeCostMult.Add(idlePercentageUpgradeCostMult[i - 1] + 0.05);
                }
                idlePercentageUpgradeNames.Add("+ " + (Controller.instance.Symbolize(idlePercentageUpgradeBasePower[i])) + "% $ / s");
                Upgrades upgrade = Instantiate(idlePercentageUpgradePrefab, idlePercentageUpgradesPanel);
                upgrade.UpgradeID = i;
                idlePercentageUpgrades.Add(upgrade);
            }
    }     
    public void UpdateUpgradeUI()
    {
        UpdateClickUpgradeUI();
        UpdateIdleUpgradeUI();
        UpdateUpgradeUpgradeUI();
        UpdateClickPercentageUpgradeUI();
        UpdateIdlePercentageUpgradeUI();
    }
    public void UpdateClickUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < clickUpgrades.Count; i++) UpdateClickUI(i);
        else UpdateClickUI(UpgradeID);
        void UpdateClickUI(int ID)
        {
            clickUpgrades[ID].LevelText.text = $"{data.clickUpgradeLevel[ID]}";
            clickUpgrades[ID].CostText.text = $"Cost: $ {Controller.instance.Symbolize(ClickUpgradeCost(ID))}";
            clickUpgrades[ID].DescriptionText.text = $"{clickUpgradeNames[ID]}";
        }
    }
    public void UpdateIdleUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < idleUpgrades.Count; i++) UpdateIdleUI(i);
        else UpdateIdleUI(UpgradeID);
        void UpdateIdleUI(int ID)
        {
            idleUpgrades[ID].LevelText.text = $"{data.idleUpgradeLevel[ID]}";
            idleUpgrades[ID].CostText.text = $"Cost: $ {Controller.instance.Symbolize(IdleUpgradeCost(ID))}";
            idleUpgrades[ID].DescriptionText.text = $"{idleUpgradeNames[ID]}";
        }
    }
    public void UpdateUpgradeUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < upgradeUpgrades.Count; i++) UpdateUpgradeUI(i);
        else UpdateUpgradeUI(UpgradeID);
        void UpdateUpgradeUI(int ID)
        {
            upgradeUpgrades[ID].LevelText.text = $"{data.upgradeUpgradeLevel[ID]}";
            upgradeUpgrades[ID].CostText.text = $"Cost: $ {Controller.instance.Symbolize(UpgradeUpgradeCost(ID))}";
            upgradeUpgrades[ID].DescriptionText.text = $"{upgradeUpgradeNames[ID]}";
        }
    }
    public void UpdateClickPercentageUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < clickPercentageUpgrades.Count; i++) UpdateClickPercentageUI(i);
        else UpdateClickPercentageUI(UpgradeID);
        void UpdateClickPercentageUI(int ID)
        {
            clickPercentageUpgrades[ID].LevelText.text = $"{data.clickPercentageUpgradeLevel[ID]}";
            clickPercentageUpgrades[ID].CostText.text = $"Cost: $ {Controller.instance.Symbolize(ClickPercentageUpgradeCost(ID))}";
            clickPercentageUpgrades[ID].DescriptionText.text = $"{clickPercentageUpgradeNames[ID]}";
        }
    }
    public void UpdateIdlePercentageUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < idlePercentageUpgrades.Count; i++) UpdateIdlePercentageUI(i);
        else UpdateIdlePercentageUI(UpgradeID);
        void UpdateIdlePercentageUI(int ID)
        {
            idlePercentageUpgrades[ID].LevelText.text = $"{data.idlePercentageUpgradeLevel[ID]}";
            idlePercentageUpgrades[ID].CostText.text = $"Cost: $ {Controller.instance.Symbolize(IdlePercentageUpgradeCost(ID))}";
            idlePercentageUpgrades[ID].DescriptionText.text = $"{idlePercentageUpgradeNames[ID]}";
        }
    }
    public double UpgradeCostReduction() => 1 - Controller.instance.UpgradePower();
    public double IdleUpgradeCost(int UpgradeID) => Math.Round((idleUpgradeBaseCost[UpgradeID] * Math.Pow(idleUpgradeCostMult[UpgradeID], Controller.instance.data.idleUpgradeLevel[UpgradeID]))* UpgradeCostReduction(),3);
    public double ClickUpgradeCost(int UpgradeID) => Math.Round((clickUpgradeBaseCost[UpgradeID] * Math.Pow(clickUpgradeCostMult[UpgradeID], Controller.instance.data.clickUpgradeLevel[UpgradeID]))* UpgradeCostReduction(),3);
    public double UpgradeUpgradeCost(int UpgradeID) => Math.Round((upgradeUpgradeBaseCost[UpgradeID] * Math.Pow(upgradeUpgradeCostMult[UpgradeID], Controller.instance.data.upgradeUpgradeLevel[UpgradeID]))* UpgradeCostReduction(),3);
    public double IdlePercentageUpgradeCost(int UpgradeID) => Math.Round((idlePercentageUpgradeBaseCost[UpgradeID] * Math.Pow(idlePercentageUpgradeCostMult[UpgradeID], Controller.instance.data.idlePercentageUpgradeLevel[UpgradeID])) * UpgradeCostReduction(), 3);
    public double ClickPercentageUpgradeCost(int UpgradeID) => Math.Round((clickPercentageUpgradeBaseCost[UpgradeID] * Math.Pow(clickPercentageUpgradeCostMult[UpgradeID], Controller.instance.data.clickPercentageUpgradeLevel[UpgradeID])) * UpgradeCostReduction(), 3);
    public void BuyClickUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        if (data.dollars >= (ClickUpgradeCost(UpgradeID)))
        {
            data.dollars -= (ClickUpgradeCost(UpgradeID));
            data.clickUpgradeLevel[UpgradeID] += 1;
            UpdateClickUpgradeUI(UpgradeID);
        }
    }
    public void BuyAllClickUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        while (data.dollars >= (ClickUpgradeCost(UpgradeID)))
        {
            data.dollars -= (ClickUpgradeCost(UpgradeID));
            data.clickUpgradeLevel[UpgradeID] += 1;
            UpdateClickUpgradeUI(UpgradeID);
        }
    }
    public void BuyIdleUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
            if (data.dollars >= (IdleUpgradeCost(UpgradeID)))
            {
                data.dollars -= (IdleUpgradeCost(UpgradeID));
                data.idleUpgradeLevel[UpgradeID] += 1;
                UpdateIdleUpgradeUI(UpgradeID);
            }    
    }
    public void BuyAllIdleUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        while (data.dollars >= (IdleUpgradeCost(UpgradeID)))
        {
            data.dollars -= (IdleUpgradeCost(UpgradeID));
            data.idleUpgradeLevel[UpgradeID] += 1;
            UpdateIdleUpgradeUI(UpgradeID);
        }
    }
    public void BuyUpgradeUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
            if (data.dollars >= (UpgradeUpgradeCost(UpgradeID)))
            {
                data.dollars -= (UpgradeUpgradeCost(UpgradeID));
                data.upgradeUpgradeLevel[UpgradeID] += 1;
                UpdateUpgradeUI();
            }
    }
    public void BuyAllUpgradeUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        while (data.dollars >= (UpgradeUpgradeCost(UpgradeID)))
        {
            data.dollars -= (UpgradeUpgradeCost(UpgradeID));
            data.upgradeUpgradeLevel[UpgradeID] += 1;
            UpdateUpgradeUpgradeUI(UpgradeID);
        }
    }
    public void BuyClickPercentageUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        if (data.dollars >= (ClickPercentageUpgradeCost(UpgradeID)))
        {
            data.dollars -= (ClickPercentageUpgradeCost(UpgradeID));
            data.clickPercentageUpgradeLevel[UpgradeID] += 1;
            UpdateClickPercentageUpgradeUI(UpgradeID);
        }
    }
    public void BuyAllClickPercentageUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        while (data.dollars >= (ClickPercentageUpgradeCost(UpgradeID)))
        {
            data.dollars -= (ClickPercentageUpgradeCost(UpgradeID));
            data.clickPercentageUpgradeLevel[UpgradeID] += 1;
            UpdateClickPercentageUpgradeUI(UpgradeID);
        }
    }
    public void BuyIdlePercentageUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        if (data.dollars >= (IdlePercentageUpgradeCost(UpgradeID)))
        {
            data.dollars -= (IdlePercentageUpgradeCost(UpgradeID));
            data.idlePercentageUpgradeLevel[UpgradeID] += 1;
            UpdateIdlePercentageUpgradeUI(UpgradeID);
        }
    }
    public void BuyAllIdlePercentageUpgrade(int UpgradeID)
    {
        var data = Controller.instance.data;
        while (data.dollars >= (IdlePercentageUpgradeCost(UpgradeID)))
        {
            data.dollars -= (IdlePercentageUpgradeCost(UpgradeID));
            data.idlePercentageUpgradeLevel[UpgradeID] += 1;
            UpdateIdlePercentageUpgradeUI(UpgradeID);
        }
    }
}
