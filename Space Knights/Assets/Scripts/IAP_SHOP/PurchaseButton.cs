using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType { removeAds, coin100, coin250};
    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.removeAds:
                IAPManager.instance.BuyRemoveAds();
                break;
            case PurchaseType.coin100:
                IAPManager.instance.Buy100Coins();
                break;
            case PurchaseType.coin250:
                IAPManager.instance.Buy250Coins();
                break;
        }
    }

}
