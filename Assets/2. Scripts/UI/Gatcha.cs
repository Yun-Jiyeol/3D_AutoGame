using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatcha : MonoBehaviour
{
    public GameObject GatchaRewardUI;

    [SerializeField] List<ItemScript> Rewards = new List<ItemScript>();

    public void ClickGoldBth()
    {
        if(GameManager.instance.player.Gold >= 10000)
        {
            GameManager.instance.player.Gold -= 10000;
            GetReward(1);
        }
    }

    public void ClickDiaBth()
    {
        if (GameManager.instance.player.Dia >= 100)
        {
            GameManager.instance.player.Dia -= 100;
            GetReward(10);
        }
    }

    void GetReward(int num)
    {
        Rewards.Clear();

        for (int i = 0; i < num; i++)
        {
            Rewards.Add(RandomItem());
        }

        SetRewardUI();
    }

    void SetRewardUI()
    {
        GatchaRewardUI.SetActive(true);
        GatchaRewardUI.GetComponent<Reward>().CheckingRewards(Rewards);
    }

    ItemScript RandomItem()
    {
        int Rare;
        int i = Random.Range(0, 100);
        if(i < 40)
        {
            Rare = 0;
        }else if (i < 70)
        {
            Rare = 1;
        }
        else if(i < 90)
        {
            Rare = 2;
        }
        else
        {
            Rare = 3;
        }

        switch (Random.Range(0, 4))
        {
            case 0:
                GameManager.instance.itemManager.Head[Rare].PlayerHave++;
                GameManager.instance.itemManager.upgradeHeadStat(Rare);
                return GameManager.instance.itemManager.Head[Rare];
            case 1:
                GameManager.instance.itemManager.Body[Rare].PlayerHave++;
                GameManager.instance.itemManager.upgradeBodyStat(Rare);
                return GameManager.instance.itemManager.Body[Rare];
            case 2:
                GameManager.instance.itemManager.Boots[Rare].PlayerHave++;
                GameManager.instance.itemManager.upgradeBootsStat(Rare);
                return GameManager.instance.itemManager.Boots[Rare];
            default:
                GameManager.instance.itemManager.Weapon[Rare].PlayerHave++;
                GameManager.instance.itemManager.upgradeWeaponStat(Rare);
                return GameManager.instance.itemManager.Weapon[Rare];
        }
    }
}
