using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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

    public int Dammage
    {
        get { return this.dammage; }
    }

    public AudioClip clip;
    private AudioSource audioSrc;

    private void Start()
    {
        Invoke("destBullet", timeAutoDestory);

        audioSrc = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(!(coll.gameObject.tag == tagEnemy))
            return;

        if (coll.gameObject.tag == tagEnemy)
        {
            Ship ship = coll.GetComponent<Ship>();
            ship.makeDammage(dammage);

            if (!ship.IsAlive) ship.destoryEnemy();

            audioSrc.Play();
        }        
    }

    private void destBullet()
    {
        Destroy(gameObject);
    }
}
