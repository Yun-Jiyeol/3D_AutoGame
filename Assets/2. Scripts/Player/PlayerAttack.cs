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
            GameManager.instance.MonsterInStage[Random.Range(0, GameManager.instance.MonsterInStage.Count)].GetComponent<Monster>().GetDamage(GameManager.instance.player.AttackDamage);
            Debug.Log("Attack");
            yield return new WaitForSeconds(1/ GameManager.instance.player.Speed * 2);
        }
    }
}
