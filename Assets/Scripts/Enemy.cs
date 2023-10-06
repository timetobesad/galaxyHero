using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour, Ship
{
    public float speed;

    public string tagDestroyed;

    private int id;

    private Camera cam;
    private Vector3 screenPos;

    public Vector2 hpBarSize;

    public Texture2D hpBarTexture;

    [SerializeField]
    private int healthVal = 100;

    [SerializeField]
    private int pointForDestroy = 0;

    [SerializeField]
    private bool isShoting = false;

    [SerializeField]
    private float delayShot = 0;

    [SerializeField]
    private Weapon weapon;

    public int PointForDestroy
    {
        get { return this.pointForDestroy; }
    }

    public int Id
    {
        get { return this.id; }
    }

    public bool IsLAlive
    {
        get { return healthVal > 0; }
    }

    public bool IsAlive
    {
        get { return this.healthVal > 0; }
    }

    public AudioClip clipHit;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        cam = FindAnyObjectByType<Camera>();

        if (isShoting)
            InvokeRepeating("shot", 0, delayShot);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));

        screenPos = cam.WorldToScreenPoint(transform.position);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(screenPos.x - (hpBarSize.x / 2), Screen.height - screenPos.y - 70 - (hpBarSize.y / 2), hpBarSize.x, hpBarSize.y), healthVal.ToString());
        GUI.DrawTexture(new Rect(screenPos.x - (hpBarSize.x / 2), Screen.height - screenPos.y - 70 - (hpBarSize.y / 2), hpBarSize.x, hpBarSize.y), hpBarTexture);
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

    public void makeDammage(int dammage)
    {
        healthVal -= dammage;
    }

    private void shot()
    {
        if (!isShoting) return;

        for (int i = 0; i < weapon.Cannons.Length; i++)
        {
            GameObject shell = Instantiate(weapon.BulletPref, weapon.Cannons[i].position, weapon.Cannons[i].rotation);
            shell.GetComponent<Bullet>().hit = hitFromPlayer;
        }
    }

    public void hitFromPlayer(GameObject hitObj, Bullet bullet)
    {
        if (hitObj.tag == bullet.TagEnemy)
        {
            if (audioSrc)
            {
                if (!audioSrc.isPlaying)
                {
                    audioSrc.clip = clipHit;
                    audioSrc.Play();
                }
            }

            hitObj.GetComponent<HealthManager>().makeDamge(bullet.Dammage);
        }
    }

    public void destoryEnemy()
    {
        FindAnyObjectByType<ScoreManager>().addPoint(pointForDestroy);

        EnemySpawn enSys = FindObjectOfType<EnemySpawn>();
        enSys.freeId(id);
        enSys.spawn();
        Destroy(gameObject);
    }
}
