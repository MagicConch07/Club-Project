using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] private List<ItemSetting> items = new List<ItemSetting>();
    public static ShopManager instance;
    [SerializeField] private Button closeBtn;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("CardManager is running!");
        }
        instance = this;

        closeBtn.onClick.AddListener(OffShop);
        canvasGroup = GetComponent<CanvasGroup>();  
    }
    public void SelectCard(ItemSO itemSO)
    {
        //itemSO에 있는 값으로 stat 증가(stat만들어지면)
    }

    public void OffCardPanel(GameObject item)
    {
        item.SetActive(false);
    }

    public void ItemSetting(ItemSO first, ItemSO second, ItemSO third)
    {
        canvasGroup.DOFade(1, 1);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        items[0].SettingInfo(first);
        items[1].SettingInfo(second);
        items[2].SettingInfo(third);
    }

    private void OffShop()
    {
        canvasGroup.DOFade(0, 1);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
