using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public List<ItemScript> Head;
    public List<ItemScript> Body;
    public List<ItemScript> Boots;
    public List<ItemScript> Weapon;

    private void Start()
    {
        GameManager.instance.itemManager = this;
    }

    public void upgradeHeadStat(int Rare)
    {
        if (Head[Rare].PlayerHave >= Head[Rare].Upgrade + 1)
        {
            if (GameManager.instance.player.Head == Head[Rare])
            {
                SubStat(Head[Rare]);
                Head[Rare].PlayerHave -= Head[Rare].Upgrade;
                Head[Rare].Upgrade++;
                Head[Rare].CriticalRate++;
                AddStat(Head[Rare]);
            }
            else
            {
                Head[Rare].PlayerHave -= Head[Rare].Upgrade;
                Head[Rare].Upgrade++;
                Head[Rare].CriticalRate++;
            }
        }
    }
    public void upgradeBodyStat(int Rare)
    {
        if (Body[Rare].PlayerHave >= Body[Rare].Upgrade + 1)
        {
            if (GameManager.instance.player.Body == Body[Rare])
            {
                SubStat(Body[Rare]);
                Body[Rare].PlayerHave -= Body[Rare].Upgrade;
                Body[Rare].Upgrade++;
                Body[Rare].Hp += 10;
                AddStat(Body[Rare]);
            }
            else
            {
                Body[Rare].PlayerHave -= Body[Rare].Upgrade;
                Body[Rare].Upgrade++;
                Body[Rare].Hp += 10;
            }
        }
    }
    public void upgradeBootsStat(int Rare)
    {
        if (Boots[Rare].PlayerHave >= Boots[Rare].Upgrade + 1)
        {
            if (GameManager.instance.player.Boots == Boots[Rare])
            {
                SubStat(Boots[Rare]);
                Boots[Rare].PlayerHave -= Boots[Rare].Upgrade;
                Boots[Rare].Upgrade++;
                Boots[Rare].Speed += 0.2f;
                AddStat(Boots[Rare]);
                GameManager.instance.player.ChangeSpeed();
            }
            else
            {
                Boots[Rare].PlayerHave -= Boots[Rare].Upgrade;
                Boots[Rare].Upgrade++;
                Boots[Rare].Speed += 0.2f;
            }
        }
    }
    public void upgradeWeaponStat(int Rare)
    {
        if (Weapon[Rare].PlayerHave >= Weapon[Rare].Upgrade + 1)
        {
            if (GameManager.instance.player.Weapon == Weapon[Rare])
            {
                SubStat(Weapon[Rare]);
                Weapon[Rare].PlayerHave -= Weapon[Rare].Upgrade;
                Weapon[Rare].Upgrade++;
                Weapon[Rare].Attack += 1f;
                AddStat(Weapon[Rare]);
            }
            else
            {
                Weapon[Rare].PlayerHave -= Weapon[Rare].Upgrade;
                Weapon[Rare].Upgrade++;
                Weapon[Rare].Attack += 1f;
            }
        }
    }

    void AddStat(ItemScript _item)
    {
        GameManager.instance.player.Hp += _item.Hp;
        GameManager.instance.player.MaxHp += _item.Hp;
        GameManager.instance.player.AttackDamage += _item.Attack;
        GameManager.instance.player.CriticalRate += _item.CriticalRate;
        GameManager.instance.player.Speed += _item.Speed;
    }

    void SubStat(ItemScript _item)
    {
        GameManager.instance.player.Hp -= _item.Hp;
        GameManager.instance.player.MaxHp -= _item.Hp;
        GameManager.instance.player.AttackDamage -= _item.Attack;
        GameManager.instance.player.CriticalRate -= _item.CriticalRate;
        GameManager.instance.player.Speed -= _item.Speed;
    }
}
