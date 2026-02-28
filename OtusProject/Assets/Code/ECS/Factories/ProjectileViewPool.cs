using System.Collections;
using System.Collections.Generic;
using Zenject;

public class ProjectileViewPool
{
    private readonly ProjectileView _prefab;
    private readonly DiContainer _container;

    private readonly Stack<ProjectileView> _pool = new();

    public ProjectileViewPool(ProjectileView prefab, DiContainer container)
    {
        _prefab = prefab;
        _container = container;
    }

    public ProjectileView Get()
    {
        if(_pool.Count > 0)
        {
            var view = _pool.Pop();
            view.gameObject.SetActive(true);
            return view;
        }

        return _container.InstantiatePrefabForComponent<ProjectileView>(_prefab);
    }

    public void Return(ProjectileView view)
    {
        view.gameObject.SetActive(false);
        _pool.Push(view);
    }
}

