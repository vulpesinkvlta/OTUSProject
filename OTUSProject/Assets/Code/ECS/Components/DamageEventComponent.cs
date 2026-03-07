using Entitas;

[Game]
public sealed class DamageEventComponent : IComponent
{
    public GameEntity Target;
    public float Value;
}