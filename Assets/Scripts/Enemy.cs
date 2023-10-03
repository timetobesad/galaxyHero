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

    public int Id
    {
        get { return this.id; }
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
        GUI.Box(new Rect(screenPos.x - (hpBarSize.x / 2), Screen.height - screenPos.y - 70 - (hpBarSize.y / 2), hpBarSize.x, hpBarSize.y), "100");
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
}
