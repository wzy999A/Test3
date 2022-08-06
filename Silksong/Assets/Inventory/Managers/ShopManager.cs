using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager 
{

    public InventorySO inventory;
    public void Add(string npcId,string shopItemId)//解锁新商品
    {
        InventorySO inventory = Resources.Load<InventorySO>(npcId);
        InventorySO inventory2 = Resources.Load<InventorySO>(shopItemId);
    }

    public void OpenShop(string npcId)
    {

        inventory = Resources.Load<InventorySO>("UI/"+npcId);
        //ShopSaveManager.Instance.LoadPlayerData();
        
        if(inventory.Items.Count>0)
        {
            Object prefab = Resources.Load("UI/UIShop");
            GameObject go = (GameObject)GameObject.Instantiate(prefab);
            UIShop uishop = go.GetComponent<UIShop>();
            uishop.SetShop(inventory);
        }
    }


    private static ShopManager _instance;
    public static ShopManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ShopManager();
            }
            return _instance;
        }
    }

}

