using Entitas;

public enum WeaponType
{
    Melee,
    Projectile
}

[Game]
public sealed class WeaponComponent : IComponent
{
    public WeaponType Type;
    public float ProjectileSpeed;
}