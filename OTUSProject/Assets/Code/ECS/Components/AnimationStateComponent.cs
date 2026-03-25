using Entitas;

[Game]
public class AnimationStateComponent : IComponent
{
    public AnimationState Value;
}

public enum AnimationState
{
    Idle,
    Walk,
    Attack,
    Death
}