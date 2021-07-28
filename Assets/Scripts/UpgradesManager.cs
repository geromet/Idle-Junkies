using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    public List<Upgrades> clickUpgrades;
    public List<Upgrades> idleUpgrades;
    public List<Upgrades> upgradeUpgrades;
    public Upgrades clickUpgradePrefab;
    public ScrollRect clickUpgradesScroll;
    public Transform clickUpgradesPanel;
    public List<string> clickUpgradeNames;
    public List<double> clickUpgradeBaseCost;
    public List<double> clickUpgradeCostMult;
    public List<double> clickUpgradeBasePower;
    public Upgrades idleUpgradePrefab;
    public ScrollRect idleUpgradesScroll;
    public Transform idleUpgradesPanel;
    public List<string> idleUpgradeNames;
    public List<double> idleUpgradeBaseCost;
    public List<double> idleUpgradeCostMult;
    public List<double> idleUpgradeBasePower;
    [SerializeField] Upgrades upgradeUpgradePrefab;
    [SerializeField] ScrollRect upgradeUpgradesScroll;
    [SerializeField] Transform upgradeUpgradesPanel;
    public List<string> upgradeUpgradeNames;
    public List<double> upgradeUpgradeBaseCost;
    public List<double> upgradeUpgradeCostMult;
    public List<double> upgradeUpgradeBasePower;



    public void Awake() => instance = this;

    public void StartUpgradeManager()
    {
        InitializeBaseValues();
        clickUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        upgradeUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        idleUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        UpdateUpgradeUI();
    }
    public void UpdateUpgradeUI()
    {
        UpdateClickUpgradeUI();
        UpdateIdleUpgradeUI();
        UpdateUpgradeUpgradeUI();
    }

    private void InitializeBaseValues()
    {
        clickUpgradeBaseCost = new double[Controller.instance.data.clickUpgradeLevel.Count].ToList();
        clickUpgradeBasePower = new double[Controller.instance.data.clickUpgradeLevel.Count].ToList();
        clickUpgradeCostMult = new double[Controller.instance.data.clickUpgradeLevel.Count].ToList();
        idleUpgradeBaseCost = new double[Controller.instance.data.idleUpgradeLevel.Count].ToList();
        idleUpgradeBasePower = new double[Controller.instance.data.idleUpgradeLevel.Count].ToList();
        idleUpgradeCostMult = new double[Controller.instance.data.idleUpgradeLevel.Count].ToList();
        upgradeUpgradeBaseCost = new double[Controller.instance.data.upgradeUpgradeLevel.Count].ToList();
        upgradeUpgradeBasePower = new double[Controller.instance.data.upgradeUpgradeLevel.Count].ToList();
        upgradeUpgradeCostMult = new double[Controller.instance.data.upgradeUpgradeLevel.Count].ToList();
        clickUpgradeBaseCost[0] = 10;
        clickUpgradeBasePower[0] = 1;
        clickUpgradeCostMult[0] = 1.1;
        idleUpgradeBaseCost[0] = 20;
        idleUpgradeBasePower[0] = 0.5;
        idleUpgradeCostMult[0] = 1.1;
        upgradeUpgradeBaseCost[0] = 40;
        upgradeUpgradeBasePower[0] = 0.00001;
        upgradeUpgradeCostMult[0] = 1.2;
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
            clickUpgradeNames.Add("+ " + ((clickUpgradeBasePower[i] * 100) + "$ / click"));
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
            idleUpgradeNames.Add("+ " + (idleUpgradeBasePower[i] * 100) + "$ / s");
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
            upgradeUpgradeNames.Add("- " + (upgradeUpgradeBasePower[i] * 100) + "% cost");
            Upgrades upgrade = Instantiate(upgradeUpgradePrefab, upgradeUpgradesPanel);
            upgrade.UpgradeID = i;
            upgradeUpgrades.Add(upgrade);
        }
    }
    public void UpdateClickUpgradeUI(int UpgradeID = -1)
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
    public void UpdateIdleUpgradeUI(int UpgradeID = -1)
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
    public void UpdateUpgradeUpgradeUI(int UpgradeID = -1)
    {
        var data = Controller.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < upgradeUpgrades.Count; i++) UpdateUpgradeUI(i);
        else UpdateUpgradeUI(UpgradeID);
        void UpdateUpgradeUI(int ID)
        {
            upgradeUpgrades[ID].LevelText.text = $"{data.upgradeUpgradeLevel[ID].ToString()}";
            upgradeUpgrades[ID].CostText.text = $"Cost: $ {UpgradeUpgradeCost(ID)}";
            upgradeUpgrades[ID].DescriptionText.text = $"{upgradeUpgradeNames[ID]}";
        }
    }

    public double IdleUpgradeCost(int UpgradeID) => Math.Round((idleUpgradeBaseCost[UpgradeID] * Math.Pow(idleUpgradeCostMult[UpgradeID], Controller.instance.data.idleUpgradeLevel[UpgradeID]))* UpgradeCostReduction(),3);

    public double ClickUpgradeCost(int UpgradeID) => Math.Round((clickUpgradeBaseCost[UpgradeID] * Math.Pow(clickUpgradeCostMult[UpgradeID], Controller.instance.data.clickUpgradeLevel[UpgradeID]))* UpgradeCostReduction(),3);
    public double UpgradeUpgradeCost(int UpgradeID) => Math.Round((upgradeUpgradeBaseCost[UpgradeID] * Math.Pow(upgradeUpgradeCostMult[UpgradeID], Controller.instance.data.upgradeUpgradeLevel[UpgradeID]))* UpgradeCostReduction(),3);
    public double UpgradeCostReduction() => 1 - Controller.instance.UpgradePower();
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
}
