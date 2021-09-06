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
    readonly string[] symbols = new string[22] { "", "Kil", "Mil", "Bil", "Tri", "Qua", "Qui", "Sex", "Sep","Oct","Non", "Dec", "Und", "Duo", "Tre", "Qua", "Qui", "Sexde", "Septe", "Octo", "Nov","Vig" };
    public double Power(string UpgradeType)
    {
        double total = 0;
        switch (UpgradeType)
        {
            case "Click":
                for (int i = 0; i < data.clickUpgradeLevel.Count; i++)
                    total += UpgradesManager.instance.clickUpgradeBasePower[i] * data.clickUpgradeLevel[i];
                break;
            case "Idle":
                for (int i = 0; i < data.idleUpgradeLevel.Count; i++)
                    total += UpgradesManager.instance.idleUpgradeBasePower[i] * data.idleUpgradeLevel[i];
                break;
            case "Cost":
                for (int i = 0; i < data.upgradeUpgradeLevel.Count; i++)
                    total += UpgradesManager.instance.upgradeUpgradeBasePower[i] * data.upgradeUpgradeLevel[i];
                break;
            case "ClickPercentage":
                for (int i = 0; i < data.clickPercentageUpgradeLevel.Count; i++)
                    total += UpgradesManager.instance.clickPercentageUpgradeBasePower[i] * data.clickPercentageUpgradeLevel[i];
                break;
            case "IdlePercentage":
                for (int i = 0; i < data.idlePercentageUpgradeLevel.Count; i++)
                    total += UpgradesManager.instance.idlePercentageUpgradeBasePower[i] * data.idlePercentageUpgradeLevel[i];
                break;
            default:
                break;
        }

        
        return total;
    }
    private void Awake() => instance = this;
    private void Start()
    {
        data = gameObject.AddComponent<Data>();
        UpgradesManager.instance.StartUpgradeManager();
        InvokeRepeating("GenerateIdleDollars", 1f, 1f);
        UpgradesManager.instance.UpdateUpgradeUI("All");
    }
    private void Update()
    {
        dollarText.text = "$ " + Symbolize(data.dollars);
        clickPowerText.text = "+" + Symbolize((1+Power("Click"))) + " per click";
        idlePowerText.text = "+" + Symbolize(Power("Idle")) + " per second";
        clickPercentagePowerText.text = "+" + Symbolize(Power("ClickPercentage")) + "% per click";
        idlePercentagePowerText.text = "+" + Symbolize(Power("IdlePercentage")) + "% / S";
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
        data.dollars += ((1 + Power("Click")) * (1+Power("ClickPercentage"))) ;
    }
    public void GenerateIdleDollars()
    {
        data.dollars += Power("Idle") * Power("IdlePercentage") ;
    }      
}
