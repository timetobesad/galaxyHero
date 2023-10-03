using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject parrentPoint;

    public string tagPoint;

    private EnemyInfo[] enemys;

    public GameObject enemyPref;

    private void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tagPoint);

        enemys = new EnemyInfo[objs.Length];

        for (int i = 0; i < objs.Length; i++)
            enemys[i] = new EnemyInfo(objs[i].transform.position);

        for (int i = 0; i < 5; i++)
            spawn();
    }

    public void spawn()
    {
        int id = -1;

        do
        {
            id = Random.Range(0, enemys.Length - 1);
        }
        while (!enemys[id].IsAvailable);

        GameObject enObj = Instantiate(enemyPref, enemys[id].Position, Quaternion.identity);
        enObj.GetComponent<Enemy>().setId(id);
        enemys[id].IsAvailable = false;
    }

    public void freeId(int id)
    {
        enemys[id].IsAvailable = true;
    }
}