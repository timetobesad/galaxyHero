using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo
{
    private bool isAvailable;
    private Vector3 position;

    public EnemyInfo(Vector3 position)
    {
        this.isAvailable = true;
        this.position = position;
    }

    public bool IsAvailable
    {
        get { return this.isAvailable; }
        set { isAvailable = value; }
    }

    public Vector3 Position
    {
        get { return this.position; }
    }
}
