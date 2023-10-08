using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDefence : MonoBehaviour
{
    public string[] enemyTags;

    public GameObject rockerPrf;

    public int idCannon = 0;
    public Transform[] cannons;

    private void OnTriggerEnter(Collider coll)
    {
        foreach (string tag in enemyTags)
        {
            if (tag == coll.tag)
                launchRocker(coll.gameObject);
        }
    }

    private void launchRocker(GameObject target)
    {
        GameObject rocket = Instantiate(rockerPrf, cannons[idCannon].position, cannons[idCannon].rotation);
        rocket.GetComponent<AirDefRocket>().setTarget(target);

        if (idCannon == 0)
            idCannon = 1;
        else
            idCannon = 0;
    }
}
