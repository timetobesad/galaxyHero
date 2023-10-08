using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxManager : MonoBehaviour
{
    public static LootBoxManager lootManager;

    public bool[] chances;

    public GameObject[] boxes;

    private void Start()
    {
        lootManager = this;
    }

    public void spawnLoot(Transform tr)
    {
        if (!isSpawnLoot())
            return;

        Instantiate(boxes[Random.Range(0, boxes.Length)], tr.position, tr.rotation);
    }

    private bool isSpawnLoot()
    {
        return chances[Random.Range(0, chances.Length - 1)];
    }
}
