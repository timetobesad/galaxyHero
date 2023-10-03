using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public string tagDestroyed;

    private int id;

    public int Id
    {
        get { return this.id; }
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == tagDestroyed)
        {
            Destroy(gameObject);

            EnemySpawn enSys = (EnemySpawn)FindAnyObjectByType(typeof(EnemySpawn));
            enSys.freeId(id);
            enSys.spawn();
        }
    }

    public void setId(int id)
    {
        this.id = id;
    }
}
