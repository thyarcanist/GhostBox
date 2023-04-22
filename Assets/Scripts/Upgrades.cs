using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int nCurrentPoints;
    public int nCost;
    public int nPointIncreaseAmount;

    public virtual void PurchaseUpgrade()
    {
        if (nCurrentPoints >= nCost)
        {
            nCurrentPoints -= nCost;
        }
    }
}

public class PointIncreaseI : Upgrades
{
    [Header("Point Increase I")]
    public int nPointIncreaseAmount;

    public override void PurchaseUpgrade()
    {
        base.PurchaseUpgrade();
        nPointIncreaseAmount = nPointIncreaseAmount + 1;
    }
}

public class TimeIncrease : Upgrades
{
    public TimeCounter timeCounter;

    public override void PurchaseUpgrade()
    {
        base.PurchaseUpgrade();
        timeCounter.fMaxTime += 10;
    }
}

public class TimeDecrease : Upgrades
{
    public TimeCounter timeCounter;

    public override void PurchaseUpgrade()
    {
        base.PurchaseUpgrade();
        timeCounter.fMaxTime -= 5;
    }
}