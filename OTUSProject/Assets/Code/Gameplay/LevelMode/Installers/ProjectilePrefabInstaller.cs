using UnityEngine;
using Zenject;

public class ProjectilePrefabInstaller : MonoInstaller
{
    [SerializeField] private ProjectileView _prefab;
    public override void InstallBindings()
    {
        Container.BindInstances(_prefab);
        Container.Bind<ProjectileViewPool>().AsSingle();
    }
}