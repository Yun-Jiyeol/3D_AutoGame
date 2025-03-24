using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    public Image HpBar;
    public Image ExBar;

    public void SettingOnStart()
    {
        ChangeLevel();
        ChangeHpBar();
        ChangeExBar();
    }

    public void ChangeLevel()
    {
        LevelText.text = GameManager.instance.player.Level.ToString();
    }

    public void ChangeHpBar()
    {
        HpBar.fillAmount = GameManager.instance.player.Hp / GameManager.instance.player.MaxHp;
    }

    public void ChangeExBar()
    {
        ExBar.fillAmount = (float)GameManager.instance.player.Ex / (float)GameManager.instance.player.MaxEx;
    }
}
