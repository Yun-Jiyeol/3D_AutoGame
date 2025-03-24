using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerStat stat;
    public PlayerWallet wallet;

    private void Start()
    {
        GameManager.instance.uIManager = this;
    }

    public void Setting()
    {
        stat.SettingOnStart();
        wallet.SettingOnStart();
    }
}
