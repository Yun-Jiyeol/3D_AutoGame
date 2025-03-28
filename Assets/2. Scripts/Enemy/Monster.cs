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

        GameObject go = Instantiate(GameManager.instance.DamageUI);
        go.transform.SetParent(transform, false);
        go.GetComponent<RectTransform>().transform.localScale = new Vector3(1 / gameObject.transform.localScale.x, 1 / gameObject.transform.localScale.y, 1 / gameObject.transform.localScale.z);
        go.GetComponent<RectTransform>().transform.localPosition = new Vector3(Random.Range(-1f, 1f), 1, 0);
        go.GetComponent<DamageUI>().SettingDamage(damage);

        if (Hp < 0)
        {
            GameManager.instance.player.GetComponent<Player>().GetEx(Ex);
            switch (gameObject.transform.localScale.x)
            {
                case 1.5f: //보스
                    GameManager.instance.player.GetComponent<Player>().GetGoldDia(Random.Range(GameManager.instance.Stage * 500, GameManager.instance.Stage * 1000), Random.Range(GameManager.instance.Stage * 5, GameManager.instance.Stage * 10));
                    break;
                case 3f: //일반
                    GameManager.instance.player.GetComponent<Player>().GetGoldDia(Random.Range(GameManager.instance.Stage * 10, GameManager.instance.Stage * 20), 0);
                    break;
                case 5f: //미니보스
                    GameManager.instance.player.GetComponent<Player>().GetGoldDia(Random.Range(GameManager.instance.Stage * 50, GameManager.instance.Stage * 100), Random.Range(0, GameManager.instance.Stage + 1));
                    break;
            }
            GameManager.instance.uIManager.wallet.SettingOnStart();
            GameManager.instance.MonsterInStage.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public void GetFight()
    {
        StartCoroutine(StartFight());
    }

    IEnumerator StartFight()
    {
        while(GameManager.instance.player.playernowmove == PlayerNowMove.Fight)
        {
            yield return new WaitForSeconds(2 / stat.AttackRate);
            GameObject ball = Instantiate(stat.AttackObject);
            ball.transform.position = transform.position;
            ball.GetComponent<AttackBall>().SettingDamage(AttackDamage);
        }
    }
}
