
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType { pack1,pack2,pack3};
    public PurchaseType purchaseType;
    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.pack1:
                IAPManager.instance.buyPack1();
                break;
            case PurchaseType.pack2:
                IAPManager.instance.buyPack2();
                break;
            case PurchaseType.pack3:
                IAPManager.instance.buyPack3();
                break;

        }

    }
}
