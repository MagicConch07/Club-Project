using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ItemSetting : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemName, _itemDescription, _itemDamage, _itemAttackSpeed, _itemSpeed;
    [SerializeField] private Button _buyBtn;
    private ItemSO _itemSO;

    private void Awake()
    {
        _buyBtn.onClick.AddListener(BuyBtnClick);
    }


    public void SettingInfo(ItemSO item)
    {
        _itemSO = item;
        _itemIcon.sprite = item.ItemIcon;
        _itemName.text = item.ItemName;
        _itemDescription.text = item.ItemDescription;
        _itemDamage.text = "Damage : "+item.Damage;
        _itemAttackSpeed.text = "AttackSpeed : "+item.AttackSpeed;
        _itemSpeed.text = "Speed : "+item.Speed;
    }

    private void BuyBtnClick()
    {
        //코인 생기면 주석 풀기
        //if (_itemSO.Price >= _currenCoin) return;
        ShopManager.instance.SelectCard(_itemSO);
        ShopManager.instance.OffCardPanel(gameObject);
    }
}
