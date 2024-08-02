using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private List<ItemSO> items = new List<ItemSO>();

    [SerializeField] private List<ItemSO> itemSeed = new List<ItemSO>();
    [SerializeField] private SpriteRenderer _keyButton;

    public bool isShop = false;



    private void Start()
    {
        SetSeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _keyButton.gameObject.SetActive(true);
        _keyButton.DOFade(1, 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _keyButton.gameObject.SetActive(true);
        _keyButton.DOFade(0, 0.5f);
        isShop = false;

    }

    private void GetCard()
    {
        ShopManager.instance.ItemSetting(items[0], items[1], items[2]);
    }

    private void SetSeed()
    {
        if (itemSeed.Count > 0)
            itemSeed.Clear();

        for (int i = 0; i < items.Count; ++i)
        {
            itemSeed.Add(items[i]);
        }

        //Shuffle
        for (int i = 0; i < itemSeed.Count; ++i)
        {
            int idx = Random.Range(i, items.Count);

            ItemSO temp = items[i];
            items[i] = items[idx];
            items[idx] = temp;
        }

    }

}
