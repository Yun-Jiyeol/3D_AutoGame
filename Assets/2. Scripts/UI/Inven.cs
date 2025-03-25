using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inven : MonoBehaviour
{
    public List<TextMeshProUGUI> playerstats;
    public GameObject SlotSpawnPosition;
    public GameObject Slot;
    public List<GameObject> NowSlots;

    public Button WeaponBtn;
    public Image WeaponImage;

    public Button HeadBtn;
    public Image HeadImage;

    public Button BodyBtn;
    public Image BodyImage;

    public Button BootsBtn;
    public Image BootsImage;

    private void Start()
    {
        GameManager.instance.uIManager.inven = this;
    }

    public void SettingAllStat()
    {
        playerstats[0].text = $"HP : {GameManager.instance.player.Hp} / {GameManager.instance.player.MaxHp}";
        playerstats[1].text = $"EX : {GameManager.instance.player.Ex} / {GameManager.instance.player.MaxEx}";
        playerstats[2].text = $"Level : {GameManager.instance.player.Level}";
        playerstats[3].text = $"Speed : {GameManager.instance.player.Speed}";
        playerstats[4].text = $"Attack : {GameManager.instance.player.AttackDamage}";
        playerstats[5].text = $"Critical : {GameManager.instance.player.CriticalRate}%";
    }

    public void SettingAllItem()
    {
        if (GameManager.instance.player.Weapon != null) WeaponImage.sprite = GameManager.instance.player.Weapon.icon;
        else WeaponImage.sprite = null;

        if (GameManager.instance.player.Head != null) HeadImage.sprite = GameManager.instance.player.Head.icon;
        else HeadImage.sprite = null;

        if (GameManager.instance.player.Body != null) BodyImage.sprite = GameManager.instance.player.Body.icon;
        else BodyImage.sprite = null;

        if (GameManager.instance.player.Boots != null) BootsImage.sprite = GameManager.instance.player.Boots.icon;
        else BootsImage.sprite = null;
    }

    public void SettingInven()
    {
        if(NowSlots != null)
        {
            foreach(GameObject slots in NowSlots)
            {
                Destroy(slots);
            }
        }

        NowSlots.Clear();
        FullInvenUI();
    }

    void FullInvenUI()
    {
        foreach (ItemScript item in GameManager.instance.itemManager.Head)
        {
            GameObject go = Instantiate(Slot);
            go.transform.SetParent(SlotSpawnPosition.transform);
            go.transform.localScale = Vector3.one;
            go.GetComponent<Slot>().Setting(item);
            NowSlots.Add(go);
        }
        foreach (ItemScript item in GameManager.instance.itemManager.Boots)
        {
            GameObject go = Instantiate(Slot);
            go.transform.SetParent(SlotSpawnPosition.transform);
            go.transform.localScale = Vector3.one;
            go.GetComponent<Slot>().Setting(item);
            NowSlots.Add(go);
        }
        foreach (ItemScript item in GameManager.instance.itemManager.Body)
        {
            GameObject go = Instantiate(Slot);
            go.transform.SetParent(SlotSpawnPosition.transform);
            go.transform.localScale = Vector3.one;
            go.GetComponent<Slot>().Setting(item);
            NowSlots.Add(go);
        }
        foreach (ItemScript item in GameManager.instance.itemManager.Weapon)
        {
            GameObject go = Instantiate(Slot);
            go.transform.SetParent(SlotSpawnPosition.transform);
            go.transform.localScale = Vector3.one;
            go.GetComponent<Slot>().Setting(item);
            NowSlots.Add(go);
        }
    }
}
