using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    float Damage;

    Vector3 rocation = new Vector3();

    private void Start()
    {
        rocation = GameManager.instance.player.transform.position - transform.position;

        StartCoroutine(AttackPlayer());
        Invoke("DeleteOnSky", 10f);
    }

    public void SettingDamage(float _damage)
    {
        Damage = _damage;
    }

    void DeleteOnSky()
    {
        Destroy(gameObject);
    }

    IEnumerator AttackPlayer()
    {
        while(Vector3.Distance(GameManager.instance.player.transform.position , transform.position) >= 0.1f)
        {
            transform.position += rocation.normalized * 10f * Time.deltaTime;
            yield return null;
        }

        GameManager.instance.player.GetDamage(Damage);
        Destroy(gameObject);
    }
}
