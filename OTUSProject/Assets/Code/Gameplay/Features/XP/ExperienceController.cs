
using System;
using Zenject;

public class ExperienceController : IDisposable

{
    private readonly ExperienceView _view;
    private readonly IExperienceService _experienceService;

    public ExperienceController(ExperienceView view, IExperienceService service)
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