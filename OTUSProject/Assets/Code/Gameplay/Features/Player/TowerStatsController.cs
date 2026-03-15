using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerStatsController : IInitializable, IDisposable
{
    private readonly TowerButtonView _view;
    private readonly IPlayerProgressService _progress;
    private readonly IInstantiator _instantiator;

    private TowerStats _stats;

    private List<TowerStatView> _statViews = new();

    public TowerStatsController(
        TowerButtonView view,
        IPlayerProgressService progress,
        IInstantiator instantiator)
    {
        _view = view;
        _progress = progress;
        _instantiator = instantiator;
    }

    public void Initialize()
    {
        string towerId = "BaseTower";

        _stats = _progress.GetTowerStats(towerId);

        _view.NameText.text = towerId;

        _stats.OnStatsChanged += Refresh;

        CreateStatViews();

        Refresh();
    }

    private void CreateStatViews()
    {
        CreateStat("Damage", () => _stats.Damage.ToString());
        CreateStat("FireRate", () => _stats.FireRate.ToString());
        CreateStat("Range", () => _stats.Range.ToString());
        CreateStat("Health", () => _stats.Health.ToString());
    }

    private void CreateStat(string name, System.Func<string> getter)
    {
        var item = _instantiator.InstantiatePrefabForComponent<TowerStatView>(
            Resources.Load<GameObject>("UI/StatItem"),
            _view.StatsContainer);

        item.Set(name, getter());

        _statViews.Add(item);
    }

    private void Refresh()
    {
        int i = 0;

        _statViews[i++].Set("Damage", _stats.Damage.ToString());
        _statViews[i++].Set("FireRate", _stats.FireRate.ToString());
        _statViews[i++].Set("Range", _stats.Range.ToString());
        _statViews[i++].Set("Health", _stats.Health.ToString());
    }

    public void Dispose()
    {
        _stats.OnStatsChanged -= Refresh;
    }
}