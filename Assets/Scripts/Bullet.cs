using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private string tagEnemy;

    [SerializeField]
    private int dammage;

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == tagEnemy)
        {
            Enemy enemy = coll.GetComponent<Enemy>();
            enemy.makeDammage(dammage);

            if(!enemy.IsLAlive) destroyEnemy(coll.gameObject);
        }

        Destroy(gameObject);
    }

    private void destroyEnemy(GameObject enemy)
    {
        EnemySpawn enSys = FindObjectOfType<EnemySpawn>();
        enSys.freeId(enemy.GetComponent<Enemy>().Id);
        Destroy(enemy);
        enSys.spawn();
    }
}
