using System.Linq;
using UnityEngine;
using System.Collections.Generic;
public class Data : MonoBehaviour
{
    public double dollars;
    public List<double> clickUpgradeLevel;
    public List<double> idleUpgradeLevel;

    public Data()
    {
        dollars = 0;
        clickUpgradeLevel = new double[6].ToList();
        idleUpgradeLevel = new double[6].ToList();
    }

}
