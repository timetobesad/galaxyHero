using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour, Ship
{
    public float minSpeed;
    public float maxSpeed;

    private float speed;

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

    public float delayTurn = 5;
    public bool isTurn = false;

    private bool isDestroyed = false;

    public int PointForDestroy
    {
        get { return this.pointForDestroy; }
    }

    public int Id
    {
        get { return this.id; }
    }

    public bool IsAlive
    {
        get { return this.healthVal > 0; }
    }

    public AudioClip clipHit;
    private AudioSource audioSrc;

    private List<int> dirrTurnListRand;

    private void Start()
    {
        dirrTurnListRand = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            dirrTurnListRand.Add(0);
            dirrTurnListRand.Add(1);
        }

        delayTurnShip();

        speed = Random.Range(minSpeed, maxSpeed);

        audioSrc = GetComponent<AudioSource>();

        cam = FindAnyObjectByType<Camera>();

        if (isShoting)
            InvokeRepeating("shot", 0, Random.Range(1, delayShot));
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
            destoryEnemy();
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
        if (isDestroyed)
            return;

        isDestroyed = true;

        FindAnyObjectByType<ScoreManager>().addPoint(pointForDestroy);

        EnemySpawn enSys = FindObjectOfType<EnemySpawn>();
        enSys.freeId(id);
        enSys.spawn();
        Destroy(gameObject);
    }

    private void delayTurnShip()
    {
        if (!isTurn) return;

        Invoke("turnEnemyShip", Random.Range(1, delayTurn));

        int dirr = getDirrTurn();

        if (!System.Convert.ToBoolean(dirr)) return;

        transform.Translate(dirr, 0f, 0f);
    }

    public int getDirrTurn()
    {
        int result = 0;

        do
        {
            result = Random.Range(-1, 2);
        }
        while(result == 0);

        if (!checkAvilTurn(result))
        {
            if (result == -1)
                result = 1;
            else
                result = -1;

            if (!checkAvilTurn(result))
                result = 0;
        }

        return result;
    }

    private void turnEnemyShip()
    {
        delayTurnShip();
    }

    private bool checkAvilTurn(int dirr)
    {
        Ray ray = new Ray(transform.position, new Vector3(dirr, 0, 0));

        Debug.DrawRay(ray.origin, ray.direction, Color.yellow, 2);

        if (!Physics.Raycast(ray, 1.44f))
        {
            return true;
        }

        return false;
    }
}
