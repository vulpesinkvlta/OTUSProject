
using UnityEngine;

public class EnemyFacade : MonoBehaviour 
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private EnemyAnimationController _animation;
    [SerializeField] private EnemyRotationController _rotationController;

    public EnemyView View => _view;
    public void Initialize(GameEntity gameEntity)
    {
        _view.Initialize(gameEntity);
        _animation.Initialize(gameEntity);
        _rotationController.Initialize(gameEntity);
    }
}

