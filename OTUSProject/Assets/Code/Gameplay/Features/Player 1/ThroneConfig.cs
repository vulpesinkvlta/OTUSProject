using UnityEngine;
[CreateAssetMenu(fileName = "ThroneConfig", menuName = "Game/Throne Config")]
public class ThroneConfig : ScriptableObject
{
    public ThroneView Prefab;
    public int Health;
}
