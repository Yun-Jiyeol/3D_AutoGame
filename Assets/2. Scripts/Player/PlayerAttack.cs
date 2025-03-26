using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public void StartFightPlayer()
    {
        StartCoroutine(Fighting());
    }

    IEnumerator Fighting()
    {
        while(GameManager.instance.player.playernowmove == PlayerNowMove.Fight)
        {
            GameManager.instance.player.animator.SetTrigger("Attack1");
            if(Random.Range(0,100) <= GameManager.instance.player.CriticalRate)
            {
                GameManager.instance.MonsterInStage[Random.Range(0, GameManager.instance.MonsterInStage.Count)].GetComponent<Monster>().GetDamage(GameManager.instance.player.AttackDamage * 1.5f);
            }
            else
            {
                GameManager.instance.MonsterInStage[Random.Range(0, GameManager.instance.MonsterInStage.Count)].GetComponent<Monster>().GetDamage(GameManager.instance.player.AttackDamage);
            }

            yield return new WaitForSeconds(1/ (GameManager.instance.player.Speed / 3));
        }
    }
}
