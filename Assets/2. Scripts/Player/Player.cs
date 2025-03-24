using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stat")]
    public float Hp;
    public float MaxHp;

    public int Level = 1;
    public int Ex;
    public int MaxEx;

    public float AttackDamage;
    public float Speed;
    public float CriticalRate;

    [Header("Wallet")]
    public int Gold;
    public int Dia;

    private void Start()
    {
        GameManager.instance.player = this;
    }

    public void GetDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            //게임 메니저를 통한 액션
        }
    }

    public void GetEx(int ex)
    {
        Ex += ex;
        while(Ex >= MaxEx)
        {
            Ex -= MaxEx;
            Level++;
            MaxEx = (int)(MaxEx * 1.5f);
        }
    }
}
