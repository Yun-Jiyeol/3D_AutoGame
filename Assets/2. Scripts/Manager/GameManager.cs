using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("OtherScripts")]
    public Player player;
    public UIManager uIManager;
    public ItemManager itemManager;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject DamageUI;

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
    public UnityEngine.UI.Image StageChangeUI;
    Coroutine StageChangeCoroutine;
    public int Stage = 1;
    public int MaxStage = 1;
    bool isBossSpawn = false;
    public bool StageEnd = false;

    public List<GameObject> MonsterInStage = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        uIManager.Setting();
    }

    private void Update()
    {
        if(MonsterInStage.Count == 0)
        {
            if (isBossSpawn)
            {
                if (!StageEnd)
                {
                    StageEnd = true;
                    player.playermove.ChasePosition(PlayerEndPosition.transform.position);
                    player.ChangeStat(PlayerNowMove.Move);
                }
            }
            else
            {
                StageEnd = false;
                player.playernowmove = PlayerNowMove.Idle;
                SpawnMonster();
            }
        }

        if (player.transform.position.z >= 10)
        {
            virtualCamera.Priority = 20;
        }
        else
        {
            virtualCamera.Priority = 5;
        }
    }

    private void FixedUpdate()
    {
        if(player.playernowmove == PlayerNowMove.Idle && MonsterInStage.Count != 0)
        {
            player.playermove.ChasePosition(spawnposition.transform.position);
            player.ChangeStat(PlayerNowMove.Move);
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
        if(isBossSpawn) return;
        isBossSpawn = true;

        DestroyStageMonster();
        GameObject go = Instantiate(DragonPrefab[Random.Range(0, DragonPrefab.Count)]);
        spawnposition = BossSpawnPosition;
        go.transform.position = spawnposition.transform.position;
        go.transform.localScale = bossmonsterSize;
        Monster stat = go.AddComponent<Monster>();
        stat.SetMonster(bossStat);
        MonsterInStage.Add(go);

        player.playermove.ChasePosition(spawnposition.transform.position);
        player.ChangeStat(PlayerNowMove.Move);
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

    public void DeadPlayer()
    {
        Invoke("InvokeDeadPlayer", 5f);
    }

    void InvokeDeadPlayer()
    {
        ChangeStage(0);
    }

    public void ChangeStage(int num)
    {
        if (StageChangeCoroutine != null) return;
        StageChangeCoroutine = StartCoroutine(ChangeStageCoroutine());
        Stage += num;
        uIManager.menu.SettingStageNum();
        if (MaxStage < Stage)
        {
            MaxStage = Stage;
        }
    }

    IEnumerator ChangeStageCoroutine()
    {
        while(StageChangeUI.color.a <= 1)
        {
            StageChangeUI.color += new Color(0,0,0,1) * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        player.transform.position = PlayerStartPosition.transform.position;
        player.playermove.ChasePosition(PlayerStartPosition.transform.position);

        yield return new WaitForSeconds(1f);

        while (StageChangeUI.color.a > 0)
        {
            StageChangeUI.color -= new Color(0, 0, 0, 1) * Time.deltaTime;
            yield return null;
        }

        isBossSpawn = false;
    }
}
