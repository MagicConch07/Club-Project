using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/ItemInfo")]
public class ItemSO : ScriptableObject
{
    public Sprite ItemIcon;
    public string ItemName;
    public string ItemDescription;
    public float Damage;
    public float AttackSpeed;
    public float Speed;
    public int Price;
}
