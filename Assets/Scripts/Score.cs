using System;
using UnityEngine;

public class Score 
{
    public double dollars { get; private set; }
    private double dollarBase;
    private double dollarMultiplier;
    private double dollarPower;
    private Score score;
    private Texts texts;


    public void Start()
    {
        Score score = new Score();
    }
    public void AddDollars(int amount)
    {
        dollars += amount * Math.Pow(dollarBase * dollarMultiplier, dollarPower);
    }
    public void AddDollarBase(int amount)
    {
        dollarBase += amount;
    }
    public void AddDollarMultiplier(int amount)
    {
        dollarMultiplier += amount;

    }
    public void AddDollarPower(int amount)
    {
        dollarPower += amount;

    }


}
