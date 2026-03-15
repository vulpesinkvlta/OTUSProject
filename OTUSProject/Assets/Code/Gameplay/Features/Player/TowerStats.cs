
using UnityEngine;

public class TowerStats
{
    public float Damage;
    public float FireRate;
    public float Range;
    public int Health;

    public void ApplyDamageUpgrade(float value)
    {
        Damage += value;
    }

    public void ApplyFireRateUpgrade(float value)
    {
        FireRate += value;
    }

    public void ApplyRangeUpgrade(float value)
    {
        Range += value;
    }

    public void ApplyHealthUpgrade(int value)
    {
        Health += value;
        Debug.Log(Health + "Здоровье");
    }
}