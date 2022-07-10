using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class ItemSO : SerializableScriptableObject
{
    [Tooltip("The name of the item")]
    [SerializeField] private string _id = default;

    [Tooltip("The name of the item")]
    [SerializeField] private string _name = default;

    [Tooltip("A preview image for the item")]
    [SerializeField]
    private Sprite _previewImage = default;

    [Tooltip("A description of the item")]
    [SerializeField]
    private string _description = default;
    
    [Tooltip("The type of interaction")]
    [SerializeField]
    private EInteractiveItemType _interitemType = default;

    [Tooltip("The type of item")]
    [SerializeField]
    private ItemTypeSO _itemType = default;

    [Tooltip("A prefab reference for the model of the item")]
    [SerializeField]
    private GameObject _prefab = default;
    
    [Tooltip("Price of the item")]
    [SerializeField]
    private int _price = default;

    //public string ID => _id;
    public string Name => _name;
    public EInteractiveItemType m_itemType => _interitemType;
    public Sprite PreviewImage => _previewImage;
    public string Description => _description;
    public int price =>_price;
    public ItemTypeSO ItemType => _itemType;
    public GameObject Prefab => _prefab;

    //private string _id;             // 物品id   id
    private string _nameSid;        // 物品名称  item name
    private string _descSid;        // 物品说明  item desc
    private string _buffId;         // 效果id   the id of buff
    private string _buffVal;        // 效果数值  buff effect
    private Sprite _icon = default; // 图标     icon asset
    //private bool _amount;

    public string ID => _id;
    public string NameSid => _nameSid;
    public string DescSid => _descSid;
    public string BuffID => _buffId;
    public string BuffVal => _buffVal;
    public Sprite Icon => _icon;

    //public bool Amount => _amount;

    public ItemSO(string id, string nameSid, string descSid, string buffId, string buffVal, Sprite icon)
    {
        _id = id;
        _nameSid = nameSid;
        _descSid = descSid;
        _buffId = buffId;
        _buffVal = buffVal;
        _icon = icon;
        //_amount = amount;
    }

}
