using UnityEngine;
using TMPro;
using System;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public UpgradesManager upgradesManager;
    [SerializeField] private TMP_Text clickPowerText;
    [SerializeField] private TMP_Text idlePowerText;
    [SerializeField] private TMP_Text clickPercentagePowerText;
    [SerializeField] private TMP_Text idlePercentagePowerText;
    [SerializeField] private TMP_Text dollarText;
    [SerializeField] private TMP_Text upgradePowerText;
    public Data data;
    readonly string[] symbols = new string[9] { "", "K", "M", "G", "T", "P", "E", "Z", "Y" };
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
    public double ClickPercentagePower()
    {
        double total = 0;
        for (int i = 0; i <data.clickPercentageUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.clickPercentageUpgradeBasePower[i] * data.clickPercentageUpgradeLevel[i];
        }
        return total;      
    }
    public double IdlePercentagePower()
    {
        double total = 0;
        for (int i = 0; i < data.idlePercentageUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.idlePercentageUpgradeBasePower[i] * data.idlePercentageUpgradeLevel[i];
        }
        return total;
    }
    private void Awake() => instance = this;
    private void Start()
    {
        data = gameObject.AddComponent<Data>();
        UpgradesManager.instance.StartUpgradeManager();
        InvokeRepeating("GenerateIdleDollars", 1f, 1f);
        UpgradesManager.instance.UpdateUpgradeUI();
    }
    private void Update()
    {
        dollarText.text = "$ " + Symbolize(data.dollars);
        clickPowerText.text = "+" + Symbolize((1+ClickPower())) + " per click";
        idlePowerText.text = "+" + Symbolize(IdlePower()) + " per second";
        clickPercentagePowerText.text = "+" + Symbolize(ClickPercentagePower()) + "% per click";
        idlePercentagePowerText.text = "+" + Symbolize(IdlePercentagePower()) + "% / S";
        upgradePowerText.text = "-" + Symbolize(Math.Round((100-((UpgradesManager.instance.UpgradeCostReduction() * 100))),4)) + " % upgrade cost";      
    }
    public string Symbolize(double amount)
    {
        int i = 0;
        while(amount/(1000)>=1)
        {
            amount/= 1000;
            i += 1;
        }
        return Math.Round(amount,3) + symbols[i].ToString();
    }
    public void GenerateDollars()
    {
        data.dollars += ((1 + ClickPower()) * (1+ClickPercentagePower())) ;
    }
    public void GenerateIdleDollars()
    {
        data.dollars += IdlePower() * IdlePercentagePower() ;
    }      
}
