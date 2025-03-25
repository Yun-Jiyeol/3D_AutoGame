using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inven : MonoBehaviour
{
    public List<TextMeshProUGUI> playerstats;

    public Button WeaponBtn;
    public Image WeaponImage;

    public Button HeadBtn;
    public Image HeadImage;

    public Button BodyBtn;
    public Image BodyImage;

    public Button BootsBtn;
    public Image BootsImage;

    public void SettingAllStat()
    {
        playerstats[0].text = $"HP : {GameManager.instance.player.Hp} / {GameManager.instance.player.MaxHp}";
        playerstats[1].text = $"EX : {GameManager.instance.player.Ex} / {GameManager.instance.player.MaxEx}";
        playerstats[2].text = $"Level : {GameManager.instance.player.Level}";
        playerstats[3].text = $"Speed : {GameManager.instance.player.Speed}";
        playerstats[4].text = $"Attack : {GameManager.instance.player.AttackDamage}";
        playerstats[5].text = $"Critical : {GameManager.instance.player.CriticalRate}%";
    }
}
