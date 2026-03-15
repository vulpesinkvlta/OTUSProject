using Zenject;

public class TowerStatsController
{
    private TowerButtonView _buttonView;
    private TowerStats _stats;

    [Inject]
    public void Construct(TowerStats towerStats, TowerButtonView view)
    {
        _stats = towerStats;
        _buttonView = view;
    }

    //private void UpdateUI()
    //{
    //    _buttonView.
    //}
}

