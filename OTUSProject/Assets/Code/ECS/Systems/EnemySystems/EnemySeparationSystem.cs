using Entitas;
using UnityEngine;

public class EnemySeparationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    private const float SeparationWeight = 1.4f;
    private const float SideStepWeight = 0.85f;
    private const float LookAheadFactor = 1.35f;
    private const float WaitCrowdThreshold = 3.2f;

    public EnemySeparationSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.Radius,
                GameMatcher.Velocity));
    }

    public void Execute()
    {
        var enemies = _enemies.GetEntities();

        foreach (var enemy in enemies)
        {
            Vector3 baseVelocity = enemy.velocity.value;
            Vector3 forward = baseVelocity.sqrMagnitude > 0.0001f
                ? baseVelocity.normalized
                : Vector3.zero;

            Vector3 separation = Vector3.zero;
            float leftDensity = 0f;
            float rightDensity = 0f;
            bool hasBlockerAhead = false;

            foreach (var other in enemies)
            {
                if (enemy == other)
                    continue;

   
                Vector3 offset = other.position.value - enemy.position.value;
                float dist = offset.magnitude;
                float desired = enemy.radius.Value + other.radius.Value;
                float influenceRange = desired * LookAheadFactor;

    
                if (dist <= 0.001f || dist > influenceRange)
                    continue;

           
                Vector3 awayFromOther = -offset.normalized;
                separation += awayFromOther * ((influenceRange - dist) / influenceRange);

                if (forward == Vector3.zero)
                    continue;

                float ahead = Vector3.Dot(forward, offset.normalized);
                if (ahead <= 0.2f)
                    continue;

                hasBlockerAhead = true;

                Vector3 right = new Vector3(-forward.z, 0f, forward.x);
                float side = Vector3.Dot(right, offset.normalized);
                float crowdScore = (influenceRange - dist) / influenceRange;

                if (side >= 0f)
                    rightDensity += crowdScore;
                else
                    leftDensity += crowdScore;
            }

            Vector3 adjusted = baseVelocity;

            if (forward != Vector3.zero)
            {
                Vector3 right = new Vector3(-forward.z, 0f, forward.x);

                if (hasBlockerAhead)
                {
                    bool canPassLeft = leftDensity < WaitCrowdThreshold;
                    bool canPassRight = rightDensity < WaitCrowdThreshold;

                    if (canPassLeft || canPassRight)
                    {
                        float sideSign = leftDensity <= rightDensity ? -1f : 1f;
                        adjusted += right * sideSign * SideStepWeight;
                    }
                    else
                    {
                        adjusted = Vector3.zero;
                    }
                }
            }

            adjusted += separation * SeparationWeight;

            if (adjusted.sqrMagnitude > 0.0001f)
                adjusted.Normalize();

            enemy.ReplaceVelocity(adjusted);
        }
    }

}