using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    public int Id
    {
        get { return this.id; }
    }

    public bool IsLAlive
    {
        get { return healthVal > 0; }
    }

    private void Start()
    {
        cam = FindAnyObjectByType<Camera>();
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
}
