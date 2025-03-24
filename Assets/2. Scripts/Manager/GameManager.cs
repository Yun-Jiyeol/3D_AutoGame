using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    public Player player;

    [Header("Enemy")]
    public List<GameObject> DragonPrefab;
    public List<GameObject> EnemyPrefab;
    public MonsterStat normalStat;
    public MonsterStat minibossStat;
    public MonsterStat bossStat;

    private Vector3 normalmonsterSize = new Vector3(3, 3, 3);
    private Vector3 minibossmonsterSize = new Vector3(5, 5, 5);
    private Vector3 bossmonsterSize = new Vector3(1.5f, 1.5f, 1.5f);

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
