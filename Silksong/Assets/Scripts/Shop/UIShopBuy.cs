using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopBuy : MonoBehaviour
{


    public Text Name;
    public Image Preview;
    public Image Icon;
    public Text Price;

    public GameObject Yes;
    public GameObject No;

    ItemStack buyItem;
    UIShop shop;

    private int a = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(a==0)
            {
                a = 1;
                Yes.SetActive(false);
                No.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(a==1)
            {
                a = 0;
                Yes.SetActive(true);
                No.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))//购买按钮
        {
            if(a==0)
            {
                OnClickBuy();
                Destroy(this.gameObject);
                
            }
            if(a==1)
            {
                shop.gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            
            shop.gameObject.SetActive(true);
            Destroy(this.gameObject);
            
        }
    }
    public void SetBuyInfo(UIShop Shop, ItemStack itemStack)
    {
        this.shop = Shop;
        this.buyItem = itemStack;
        this.Name.text = itemStack.Item.Name;
        this.Preview.sprite = itemStack.Item.PreviewImage;
        //this.Icon.sprite = Item.IconImage;
        //this.Price.text = Item.money.ToString();
    }

    public void OnClickBuy()
    {
        if(buyItem.Amount > 1)
        {
            buyItem.Amount--;
        }
        else
        {
            shop.shopList.Remove(buyItem.Item);
        }
        //ShopSaveManager.Instance.SaveShopData();
        Debug.Log("购买" + buyItem.Item.Name);
        Object prefab = Resources.Load("UI/UIShopSuccess");
        GameObject go = (GameObject)GameObject.Instantiate(prefab);
        UIShopSuccess suc2 = go.GetComponent<UIShopSuccess>();
        suc2.SetSuccess(shop);

    }


}
