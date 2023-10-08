using UnityEngine;

public enum lootType
{
    airDefRocket,
    health,
    armour
}

public class LootBox : MonoBehaviour
{
    public lootType type;
    public int count;

    public string tagPlayer;

    public float speed = 1;

    public float timeDest;

    private void Start()
    {
        Invoke("deleteObj", timeDest);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag != tagPlayer) return;

        LootReciver player = coll.GetComponent<LootReciver>();
        player.addLoot(type, count);

        Destroy(gameObject);
    }

    private void deleteObj()
    {
        Destroy(gameObject);
    }
}