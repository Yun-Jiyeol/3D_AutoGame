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

    private bool isSpawned = false;
    private Vector3 normalmonsterSize = new Vector3(3, 3, 3);
    private Vector3 minibossmonsterSize = new Vector3(5, 5, 5);
    private Vector3 bossmonsterSize = new Vector3(1.5f, 1.5f, 1.5f);

    [Header("Position")]
    public List<GameObject> monsterSpawnPosition;
    public GameObject BossSpawnPosition;
    public GameObject PlayerStartPosition;
    public GameObject PlayerEndPosition;

    [Header("Stage")]
    public int Stage;

    private List<GameObject> MonsterInStage = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (!isSpawned)
        {
            isSpawned = true;
            SpawnMonster();
        }
    }

    public void SpawnMonster()
    {
        GameObject spawnposition = monsterSpawnPosition[Random.Range(0, monsterSpawnPosition.Count)];
        MonsterInStage.Clear();

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
        isSpawned = true;
        MonsterInStage.Clear();
        GameObject go = Instantiate(DragonPrefab[Random.Range(0, DragonPrefab.Count)]);
        go.transform.position = BossSpawnPosition.transform.position;
        go.transform.localScale = bossmonsterSize;
        Monster stat = go.AddComponent<Monster>();
        stat.SetMonster(bossStat);
        MonsterInStage.Add(go);
    }
}
