using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI DiaText;

    public void SettingOnStart()
    {
        GoldSetting();
        DiaSetting();
    }

    public void GoldSetting()
    {
        GoldText.text = GameManager.instance.player.Gold.ToString();
    }

    public void DiaSetting()
    {
        DiaText.text = GameManager.instance.player.Dia.ToString();
    }
}
