using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerNowMove
{
    Idle,
    Move,
    Fight
}

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public PlayerMove playermove;
    public PlayerAttack playerAttack;

    [Header("Stat")]
    public float Hp;
    public float MaxHp;

    public int Level = 1;
    public int Ex;
    public int MaxEx;

    public float AttackDamage;
    public float Speed;
    public float CriticalRate;

    public PlayerNowMove playernowmove;

    [Header("Wallet")]
    public int Gold;
    public int Dia;

    private void Start()
    {
        GameManager.instance.player = this;

        playernowmove = PlayerNowMove.Idle;

        agent = GetComponent<NavMeshAgent>();
        playermove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void GetDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            //게임 메니저를 통한 액션
        }
        GameManager.instance.uIManager.stat.ChangeHpBar();
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
        GameManager.instance.uIManager.stat.ChangeLevel();
        GameManager.instance.uIManager.stat.ChangeExBar();
    }

    public void GetGoldDia(int gold, int dia)
    {
        Gold += gold;
        Dia += dia;
    }
}
