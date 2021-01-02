using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class CodlessIap3 : MonoBehaviour
{
    public GameObject purchasesucces;
    public void OnPurchaseComplete(Product product)
    {
        GameObject.FindObjectOfType<Menu>().totalMoney += 1000000;
        StartCoroutine(successfull());
    }
    IEnumerator successfull()
    {
        purchasesucces.SetActive(true);
        yield return new WaitForSeconds(3f);
        purchasesucces.SetActive(false);
    }
    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("purchase failed");
    }
}
