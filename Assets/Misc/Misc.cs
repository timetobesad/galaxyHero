using System.Collections.Generic;

public delegate void hitShot(UnityEngine.GameObject hitObj, Bullet bullet);

public interface Ship
{
    public void destoryEnemy();

    public bool IsAlive { get; }
}