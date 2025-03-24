using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    MonsterStat stat;

    float Hp;
    int Ex;
    float AttackDamage;

    public void SetMonster(MonsterStat _stat)
    {
        this.stat = _stat;

        SetPosition();
    }

    void SetPosition()
    {
        gameObject.transform.position += new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);

        Hp = stat.Hp + (GameManager.instance.Stage - 1) * 10;
        Ex = stat.Ex + (GameManager.instance.Stage - 1) * 1;
        AttackDamage = stat.AttackDamage + (GameManager.instance.Stage - 1) * 0.5f;
    }

    public void GetDamage(float damage)
    {
        Hp -= damage;

        if (Hp < 0)
        {
            GameManager.instance.player.GetComponent<Player>().GetEx(Ex);
            Destroy(gameObject);
        }
    }
}
