public interface Ship
{
    public void makeDammage(int damage);

    public void destoryEnemy();

    public bool IsAlive { get; }
}