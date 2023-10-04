using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private string tagEnemy;

    public string TagEnemy
    {
        get { return this.tagEnemy; }
    }

    [SerializeField]
    private int dammage;

    [SerializeField]
    private int timeAutoDestory = 5;

    public hitShot hit;

    public int Dammage
    {
        get { return this.dammage; }
    }

    private void Start()
    {
        Invoke("destBullet", timeAutoDestory);
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider coll)
    {
        hit(coll.gameObject, this);

        Ship ship = coll.GetComponent<Ship>();
        if (!ship.IsAlive) ship.destoryEnemy();
    }

    private void destBullet()
    {
        Destroy(gameObject);
    }
}
