using System;
using Zenject;

public class ExperienceController : IDisposable
{
    private ExperienceView _view;
    private IExperienceService _experienceService;
    private ITowerLimitService _towerLimitService;

    [Inject]
    public void Construct(ExperienceView view, IExperienceService service, ITowerLimitService towerLimitService)
    {
        _view = view;
        _experienceService = service;
        _towerLimitService = towerLimitService;
        _experienceService.OnExperienceChanged += UpdateUI;
        _experienceService.OnLevelChanged += UpdateTowerLimit;
        UpdateUI(_experienceService.CurrentXP, _experienceService.NextLevel);
        UpdateTowerLimit();
    }

    public void Dispose()
    {
        _experienceService.OnExperienceChanged -= UpdateUI;
        _experienceService.OnLevelChanged -= UpdateTowerLimit;
    }

    private void UpdateUI(int xp, int max)
    {
        _view.SetXP(xp, max);
        _view.SetLevel(_experienceService.Level);
    }

    private void UpdateTowerLimit()
    {
        int level = _experienceService.Level;

        int limit = CalculateLimit(level);

        _towerLimitService.SetLimit(limit);
    }

    private int CalculateLimit(int level)
    {
        if (level < 5)
            return 4;

        if (level < 10)
            return 6;

        return 8;
    }
}