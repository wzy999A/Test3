using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{

    /// content位置
    public Transform itemRoot;

    public InventorySO shopList;
    //public List<ItemStack> items ;

    //public ItemSO itembuy;
    public ItemStack itembuy;
    // 目标ScrollView
    public ScrollRect ScrollTarget;

    public GameObject shopitme;

    public Text itemName;
    public Text itemDescribe;
    public List<Button> btns;
    // 滚动步长,通过计算得到
    private float scrollStep = 0;

    public int index = 0;
    
    public void SetShop(InventorySO inventory)
    {
        this.shopList = inventory;
    }

    void Start()
    {
        //items = shopList.Items;
        itembuy = shopList.Items[0];
        StartCoroutine(InitItems());
        btns[0].Select();
        itemName.text = shopList.Items[index].Item.Name;
        itemDescribe.text = shopList.Items[index].Item.Description;
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if(Input.GetKeyDown(KeyCode.Z))//购买按钮
        {
            if(true)//钱够
            { //打开商店二级列表

                UIShopBuy buy = Resources.Load<UIShopBuy>("UI/UIShopBuy");
                GameObject go = Instantiate(buy.gameObject, transform.position, transform.rotation);
                UIShopBuy buy2 = go.GetComponent<UIShopBuy>();
                buy2.SetBuyInfo(this,itembuy);

                this.gameObject.SetActive(false);
            }
            else
            {

            }
        }
        if (Input.GetKeyDown(KeyCode.A))//关闭商店
        {
            Destroy(this.gameObject);
        }
        
    }

    IEnumerator InitItems()
    {
        
        foreach (ItemStack o in shopList.Items)
        {
            if (o.Amount > 0)
            {
                GameObject go = Instantiate(o.Item.Prefab, itemRoot);
                ShopItem items = go.GetComponent<ShopItem>();
                Button btn = go.GetComponent<Button>();
                btns.Add(btn);
                items.SetShopItem(o.Item);

            }
        }
        yield return null;
    }

    public void MoveDown()
    {
        if (index < shopList.Items.Count - 1)
        {
            index++;
            btns[index].Select();
            itembuy = shopList.Items[index];
            CalculationScrollStep();
            this.ScrollTarget.verticalNormalizedPosition = (float)(1 - ((float)index * scrollStep));

            itemName.text = shopList.Items[index].Item.Name;
            itemDescribe.text = shopList.Items[index].Item.Description;
        }
    }
    public void MoveUp()
    {
        if (index > 0)
        {
            index--;
            btns[index].Select();
            itembuy = shopList.Items[index];
            CalculationScrollStep();
            this.ScrollTarget.verticalNormalizedPosition = (float)(1 - ((float)index * scrollStep));
            itemName.text = shopList.Items[index].Item.Name;
            itemDescribe.text = shopList.Items[index].Item.Description;
        }
    }

    /// <summary>
    /// 根据当前列表item的数量,计算每个item滚动需要的步长
    /// </summary>
    /// <returns></returns>
    public float CalculationScrollStep()
    {
        scrollStep = (float)1f /(shopList.Items.Count - 1);
        return scrollStep;
    }

    public void RefreshShopItem()
    {
        for(int i = 0;i<itemRoot.childCount;i++)
        {
            Destroy(itemRoot.GetChild(i).gameObject);
            btns.Clear();
        }
        foreach (ItemStack o in shopList.Items)
        {
            //商品状态大于0 则在销售中,需添加商品道具的信息      
            if (o.Amount > 0)
            {
                GameObject go = Instantiate(shopitme, itemRoot);
                ShopItem items = go.GetComponent<ShopItem>();
                Button btn = go.GetComponent<Button>();
                btns.Add(btn);
                items.SetShopItem(o.Item);
            }
        }
        index = 0;
        CalculationScrollStep();
        this.ScrollTarget.verticalNormalizedPosition = (float)(1 - ((float)index * scrollStep));
        itembuy = shopList.Items[0];
        itemName.text = shopList.Items[index].Item.Name;
        itemDescribe.text = shopList.Items[index].Item.Description;
    }
}


