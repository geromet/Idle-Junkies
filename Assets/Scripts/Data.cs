using System.Linq;
using UnityEngine;
using System.Collections.Generic;
public class Data : MonoBehaviour
{
    public double dollars;
    public List<double> clickUpgradeLevel;
    public List<double> idleUpgradeLevel;
    public List<double> upgradeUpgradeLevel;
    public List<double> clickPercentageUpgradeLevel;
    public List<double> idlePercentageUpgradeLevel;

    public Data()
    {
        dollars = 0;
        clickUpgradeLevel = new double[18].ToList();
        idleUpgradeLevel = new double[18].ToList();
        upgradeUpgradeLevel = new double[8].ToList();
        clickPercentageUpgradeLevel = new double[18].ToList();
        idlePercentageUpgradeLevel = new double[18].ToList();
    }

}
