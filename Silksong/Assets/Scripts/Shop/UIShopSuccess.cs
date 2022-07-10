using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopSuccess : MonoBehaviour
{
    public GameObject suc;
    UIShop shop;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//返回商店列表
        {
            
            Destroy(shop.gameObject);
            shop.RefreshShopItem();
            //shop.gameObject.SetActive(true);
            Destroy(this.gameObject);
            /*UIShop o = Resources.Load<UIShop>("UI/UIShop");
            GameObject go = Instantiate(o.gameObject, transform.position, transform.rotation);
            */
            
            //shop.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.Z))//退出商店列表
        {
            
            Destroy(shop.gameObject);
            Destroy(suc);
            
            //shop.MoveDown();
        }
    }

    public void SetSuccess(UIShop Shop)
    {
        this.shop = Shop;
    }
}
