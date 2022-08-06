using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTest : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShopManager.Instance.OpenShop("1001");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ShopSaveManager.Instance.SaveShopData();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            ShopSaveManager.Instance.LoadPlayerData();
        }
    }
}
