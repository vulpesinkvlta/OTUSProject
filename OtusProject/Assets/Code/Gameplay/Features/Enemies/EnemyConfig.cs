using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    public EnemyView Prefab;

    public EnemyType EnemyType;
    
    public float Health;
    public int Damage;
    public float Speed;
    public float AttackRange;
    public float AttakcCooldown;
}

public enum EnemyType
{
    Melee = 0,
    Range = 1
}