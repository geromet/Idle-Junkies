using System.Linq;
using UnityEngine;
using System.Collections.Generic;
public class Data : MonoBehaviour
{
    public double dollars;
    public List<double> clickUpgradeLevel;
    public List<double> idleUpgradeLevel;
    public List<double> upgradeUpgradeLevel;

    public Data()
    {
        dollars = 0;
        clickUpgradeLevel = new double[12].ToList();
        idleUpgradeLevel = new double[12].ToList();
        upgradeUpgradeLevel = new double[9].ToList();
    }

}
