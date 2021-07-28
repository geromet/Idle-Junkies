using UnityEngine;
using TMPro;
using System;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public UpgradesManager upgradesManager;
    [SerializeField] private TMP_Text clickPowerText;
    [SerializeField] private TMP_Text idlePowerText;
    [SerializeField] private TMP_Text dollarText;
    [SerializeField] private TMP_Text upgradePowerText;
    public Data data;

    public double ClickPower()
    {
        double total = 0;
        for (int i=0;i< data.clickUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.clickUpgradeBasePower[i] * data.clickUpgradeLevel[i];
        }
        return Math.Round(total,2);
    }
    public double IdlePower()
    {
        double total = 0;
        for (int i = 0; i< data.idleUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.idleUpgradeBasePower[i] * data.idleUpgradeLevel[i];
        }
        return Math.Round(total,2);
    }
    public double UpgradePower()
    {
        double total = 0;
        for (int i = 0; i<data.upgradeUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.upgradeUpgradeBasePower[i] * data.upgradeUpgradeLevel[i];
        }
        return total;
    }
    private void Awake() => instance = this;

    private void Start()
    {
        data = new Data();
        UpgradesManager.instance.StartUpgradeManager();
        InvokeRepeating("GenerateIdleDollars", 1f, 1f);
    }
    private void Update()
    {
        dollarText.text = "$ " + data.dollars;
        clickPowerText.text = "+" + (1+ClickPower()) + " per click";
        idlePowerText.text = "+" + IdlePower() + " per second";
        if (UpgradesManager.instance.UpgradeCostReduction()!=1)
        {
            upgradePowerText.text = "-" + Math.Round((100-((UpgradesManager.instance.UpgradeCostReduction() * 100))),3) + " % upgrade cost";
        }
        else
        {
            upgradePowerText.text = "-0 % upgrade cost";
        }
        
    }
    public void GenerateDollars()
    {
        data.dollars += 1+ ClickPower();
    }
    public void GenerateIdleDollars()
    {
        data.dollars += IdlePower();
    }

    
    

}
