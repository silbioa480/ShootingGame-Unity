using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public float minTime = 0.5f;
    public float maxTime = 1.5f;
    float currentTime;
    public float createTime;
    public int poolSize = 30;
    public int HP = 1;
    public float Speed = 5;
    public float Rate = 3;
    public static List<GameObject> enemyObjectpool;
    public Transform[] SpawnPoints;

    public GameObject enemyFactory;

    public static EnemyManager Instance = null;
    void Awake()
    {
        if(Instance == null) Instance = this;
    }
    void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);

        enemyObjectpool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++) 
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectpool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.levelSwitch == true)
        {
            if(LevelManager.Instance.Level % 2 == 0) 
            {
                minTime -= 0.05f;
                maxTime -= 0.05f;
            }
            if(LevelManager.Instance.Level % 3 == 0) Rate += 0.5f;
            if(LevelManager.Instance.Level % 4 == 0) Speed += 0.5f;
            if(LevelManager.Instance.Level % 10 == 0) HP++;

            LevelManager.Instance.levelSwitch = false;
        }

        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            GameObject enemy = enemyObjectpool[0];
            if(enemyObjectpool.Count > 0)
            {
                enemy.GetComponent<Enemy>().rate = Rate;
                enemy.GetComponent<Enemy>().speed = Speed;
                enemy.GetComponent<Enemy>().hp = HP;

                enemy.SetActive(true);
                enemyObjectpool.Remove(enemy);

                int index = Random.Range(0, SpawnPoints.Length);
                enemy.transform.position = SpawnPoints[index].position;
            }

            currentTime = 0;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
