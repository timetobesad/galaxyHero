using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDefence : MonoBehaviour
{
    public GameObject rockerPrf;

    public int idCannon = 0;
    public Transform[] cannons;

    [SerializeField]
    private int countRocket;

    public int CountRocket
    {
        get { return this.countRocket; }
    }

    public void launchRocker(GameObject target)
    {
        GameObject rocket = Instantiate(rockerPrf, cannons[idCannon].position, cannons[idCannon].rotation);
        rocket.GetComponent<AirDefRocket>().setTarget(target.transform);

        if (idCannon == 0)
            idCannon = 1;
        else
            idCannon = 0;

        countRocket--;
    }

    public void addRocket(int count)
    {
        countRocket += count;
    }
}