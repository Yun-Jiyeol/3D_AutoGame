using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    private GameObject spawnposition;

    [Header("Stage")]
    public int Stage;

    public List<GameObject> MonsterInStage = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(MonsterInStage.Count == 0)
        {
            player.playernowmove = PlayerNowMove.Idle;
            SpawnMonster();
        }
    }

    private void FixedUpdate()
    {
        if(player.playernowmove == PlayerNowMove.Idle && MonsterInStage.Count != 0)
        {
            player.playermove.ChasePosition(spawnposition.transform.position);
            player.playernowmove = PlayerNowMove.Move;
        }
    }

    public void SpawnMonster()
    {
        spawnposition = monsterSpawnPosition[Random.Range(0, monsterSpawnPosition.Count)];
        DestroyStageMonster();

        for (int i = 0; i < 3; i++)
        {
            SpawnnormalMonster(spawnposition, normalmonsterSize, normalStat);
        }

        SpawnnormalMonster(spawnposition, minibossmonsterSize, minibossStat);
    }

    void SpawnnormalMonster(GameObject spawnposition, Vector3 monsterSize, MonsterStat Stat)
    {
        GameObject go = Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Count)]);
        go.transform.position = spawnposition.transform.position;
        go.transform.localScale = monsterSize;
        Monster stat = go.AddComponent<Monster>();
        stat.SetMonster(Stat);

        MonsterInStage.Add(go);
    }

    public void bossSpawn()
    {
        DestroyStageMonster();
        GameObject go = Instantiate(DragonPrefab[Random.Range(0, DragonPrefab.Count)]);
        spawnposition = BossSpawnPosition;
        go.transform.position = spawnposition.transform.position;
        go.transform.localScale = bossmonsterSize;
        Monster stat = go.AddComponent<Monster>();
        stat.SetMonster(bossStat);
        MonsterInStage.Add(go);
    }

    private void DestroyStageMonster()
    {
        if(MonsterInStage == null) return;

        foreach(GameObject go in MonsterInStage)
        {
            Destroy(go);
        }
        MonsterInStage.Clear();
    }
}
