using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monsterstat", menuName = "Enemy/Monsterstat")]
public class MonsterStat : ScriptableObject
{
    public float Hp;
    public float ResenHp;
    public int Ex;

    public GameObject AttackObject;
    public float AttackDamage;
    public float AttackRate;
}
