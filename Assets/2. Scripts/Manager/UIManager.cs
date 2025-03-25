using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerStat stat;
    public PlayerWallet wallet;
    public Menu menu;
    public Inven inven;
    public Image ChangeScene;

    private void Awake()
    {
        GameManager.instance.uIManager = this;
    }

    public void Setting()
    {
        stat.SettingOnStart();
        wallet.SettingOnStart();
    }
}
