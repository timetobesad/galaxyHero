using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootReciver : MonoBehaviour
{
    public HealthManager player;
    public AirDefence airDef;
    public WeaponManager weapon;
    public void addLoot(lootType type, int count)
    {
        Debug.Log(type);

        switch (type)
        {
            case lootType.airDefRocket:
                airDef.addRocket(count);
                break;
            case lootType.health:
                player.addHealth(count);
                break;
            case lootType.armour:
                player.addArmour(count);
                break;
        }
    }
}
