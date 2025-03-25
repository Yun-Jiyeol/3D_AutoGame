using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Boots,
    Head,
    Body,
    Weapon
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item/ItemStat")]
public class ItemScript : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite icon;

    public float Hp;
    public float Attack;
    public float Speed;
    public float CriticalRate;

    public int PlayerHave;
    public int Upgrade;
}
