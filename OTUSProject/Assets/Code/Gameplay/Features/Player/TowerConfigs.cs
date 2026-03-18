using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfigs", menuName = "Game/TowerConfigs")]
public class TowerConfigs : ScriptableObject
{
    public TowerView Prefab;    

    public string Id;
    public float Damage;
    public float FireRate;
    public float Range;
    public float HitRange;
    public int Health;
}
