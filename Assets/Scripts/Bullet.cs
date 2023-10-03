using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public string tagEnemy;
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == tagEnemy)
        {
            EnemySpawn enSys = FindObjectOfType<EnemySpawn>();
            enSys.freeId(coll.GetComponent<Enemy>().Id);
            Destroy(coll.gameObject);
            enSys.spawn();
            Destroy(gameObject);
        }
    }
}
