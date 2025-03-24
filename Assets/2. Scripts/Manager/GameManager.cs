using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Enemy")]
    public List<GameObject> DragonPrefab;
    public List<GameObject> EnemyPrefab;
    public MonsterStat normalStat;
    public MonsterStat minibossStat;
    public MonsterStat bossStat;

    [Header("Position")]
    public List<GameObject> monsterSpawnPosition;
    public GameObject BossSpawnPosition;
    public GameObject PlayerStartPosition;
    public GameObject PlayerEndPosition;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
