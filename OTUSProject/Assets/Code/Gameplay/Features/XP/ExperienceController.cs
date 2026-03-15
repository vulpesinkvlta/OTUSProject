using System;
using Zenject;

public class ExperienceController : IDisposable
{
    private ExperienceView _view;
    private IExperienceService _experienceService;

    [Inject]
    public void Construct(ExperienceView view, IExperienceService service)
    {
        _view = view;
        _experienceService = service;

        _experienceService.OnExperienceChanged += UpdateUI;

        UpdateUI(_experienceService.CurrentXP, _experienceService.NextLevel);
    }

    public void Dispose()
    {
        _experienceService.OnExperienceChanged -= UpdateUI;
    }

    private void UpdateUI(int xp, int max)
    {
        _view.SetXP(xp, max);
        _view.SetLevel(_experienceService.Level);
    }

}