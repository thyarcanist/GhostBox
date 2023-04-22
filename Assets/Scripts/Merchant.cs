using UnityEngine;

public class Merchant : MonoBehaviour
{
    public Upgrades upgrades;

    public void PurchaseUpgrade(Upgrades upgrade)
    {
        if (CanAffordUpgrade(upgrade))
        {
            upgrades = upgrade;
            upgrades.ActivateUpgrade();
        }
    }

    public bool CanAffordUpgrade(Upgrades upgrade)
    {
        return true;
    }

    public abstract class Upgrades
    {
        public abstract void ActivateUpgrade();
    }
}
