using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public void ChasePosition(Vector3 targetposition)
    {
        StartCoroutine(CoroutineChasePosition(targetposition));
    }

    IEnumerator CoroutineChasePosition(Vector3 targetposition)
    {
        GameManager.instance.player.agent.SetDestination(targetposition);

        yield return new WaitForSeconds(0.1f);

        while(GameManager.instance.player.agent.remainingDistance >= 5f)
        {
            if (GameManager.instance.player.agent.velocity == Vector3.zero)
            {
                GameManager.instance.player.agent.SetDestination(targetposition);
            }
            yield return new WaitForSeconds(0.1f);
        }

        GameManager.instance.player.playernowmove = PlayerNowMove.Fight;
        GameManager.instance.player.playerAttack.StartFightPlayer();
    }
}
