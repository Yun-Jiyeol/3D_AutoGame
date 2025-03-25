using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject Image;
    public GameObject DontHave;
    ItemScript item;

    public void Setting(ItemScript _item)
    {
        item = _item;
        Image.GetComponent<Image>().sprite = _item.icon;
        if(_item.PlayerHave == 0) DontHave.SetActive(true);
        else DontHave.SetActive(false);
    }

    public void OnclickSlotBtn()
    {
        if (item.PlayerHave == 0) return;

        switch (item.itemType)
        {
            case ItemType.Boots:
                SubStat(GameManager.instance.player.Boots);
                GameManager.instance.player.Boots = item;
                AddStat();
                break;
            case ItemType.Head:
                SubStat(GameManager.instance.player.Head);
                GameManager.instance.player.Head = item;
                AddStat();
                break;
            case ItemType.Body:
                SubStat(GameManager.instance.player.Body);
                GameManager.instance.player.Body = item;
                AddStat();
                break;
            case ItemType.Weapon:
                SubStat(GameManager.instance.player.Weapon);
                GameManager.instance.player.Weapon = item;
                AddStat();
                break;
        }

        GameManager.instance.uIManager.inven.SettingAllStat();
        GameManager.instance.uIManager.inven.SettingAllItem();
    }

    void AddStat()
    {
        GameManager.instance.player.Hp += item.Hp;
        GameManager.instance.player.MaxHp += item.Hp;
        GameManager.instance.player.AttackDamage += item.Attack;
        GameManager.instance.player.CriticalRate += item.CriticalRate;
        GameManager.instance.player.Speed += item.Attack;
    }

    void SubStat(ItemScript _item)
    {
        GameManager.instance.player.Hp -= _item.Hp;
        GameManager.instance.player.MaxHp -= _item.Hp;
        GameManager.instance.player.AttackDamage -= _item.Attack;
        GameManager.instance.player.CriticalRate -= _item.CriticalRate;
        GameManager.instance.player.Speed -= _item.Attack;
    }
}
