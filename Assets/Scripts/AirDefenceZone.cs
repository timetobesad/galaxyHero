using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDefenceZone : MonoBehaviour
{
    public AirDefence airDef;

    public string[] enemyTags;

    private void OnTriggerEnter(Collider coll)
    {
        if (airDef.CountRocket <= 0)
            return;

        foreach (string tag in enemyTags)
        {
            if (tag == coll.tag)
                airDef.launchRocker(coll.gameObject);
        }
    }
}
