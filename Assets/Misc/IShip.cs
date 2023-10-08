public interface Ship
{
    public void makeDammage(int damage);

    public void destroyEnemy(bool isSpawnLoot);

    public bool IsAlive { get; }
}