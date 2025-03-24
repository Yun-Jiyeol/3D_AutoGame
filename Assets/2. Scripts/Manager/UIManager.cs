using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerStat stat;
    public PlayerWallet wallet;
    public Menu menu;

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
