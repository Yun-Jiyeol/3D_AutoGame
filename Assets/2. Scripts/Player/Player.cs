using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerNowMove
{
    Idle,
    Move,
    Fight,
    Dead
}

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public PlayerMove playermove;
    public PlayerAttack playerAttack;
    public Animator animator;  

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

    [Header("Item")]
    public ItemScript Weapon;
    public ItemScript Head;
    public ItemScript Body;
    public ItemScript Boots;

    private void Start()
    {
        GameManager.instance.player = this;

        ChangeStat(PlayerNowMove.Idle);

        agent = GetComponent<NavMeshAgent>();
        playermove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();

        animator.SetFloat("Speed", Speed);
        StartCoroutine(Regeneration());
    }

    public void ChangeSpeed()
    {
        animator.SetFloat("Speed", Speed);
        agent.speed = Speed;
    }

    public void GetDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            ChangeStat(PlayerNowMove.Dead);
            //���� �޴����� ���� �׼�
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

    public void ChangeStat(PlayerNowMove playerNow)
    {
        if (playerNow == playernowmove) return;

        playernowmove = playerNow;

        switch (playerNow)
        {
            case PlayerNowMove.Idle:
                animator.SetBool("@Battle", false);
                animator.SetBool("@Move", false);
                break;
            case PlayerNowMove.Move:
                animator.SetBool("@Battle", false);
                animator.SetBool("@Move", true);
                break;
            case PlayerNowMove.Fight:
                animator.SetBool("@Battle", true);
                animator.SetBool("@Move", false);
                break;
            case PlayerNowMove.Dead:
                animator.SetBool("@Battle", false);
                animator.SetBool("@Move", false);
                animator.SetBool("@Dead", true);
                break;
        }
    }

    IEnumerator Regeneration()
    {
        while (playernowmove != PlayerNowMove.Dead)
        {
            Hp += MaxHp * 0.01f;
            if(Hp >= MaxHp) Hp = MaxHp;

            yield return new WaitForSeconds(5f);
        }
    }
}
