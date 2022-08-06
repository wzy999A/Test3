using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSaveManager
{
    



    /*
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SaveShopData();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadPlayerData();
        }
    }*/

    public void SaveShopData()
    {
        Save(ShopManager.Instance.inventory, ShopManager.Instance.inventory.ShopId);
    }

    public void LoadPlayerData()
    {
        Load(ShopManager.Instance.inventory, ShopManager.Instance.inventory.ShopId);
    }




    public void Save(Object data, string key)
    {
        var jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }

    public void Load(Object data,string key)
    {
        if(PlayerPrefs.HasKey(key))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), data);
        }
    }

    private static ShopSaveManager _instance;
    public static ShopSaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ShopSaveManager();
            }
            return _instance;
        }
    }
}
