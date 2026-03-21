using System.Collections.Generic;
using Code.Extensions;
using Code.Infrastructure.Data;
using Code.Infrastructure.Services.Progress;
using UnityEngine;

namespace Code.Infrastructure.Services.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private readonly IProgressService _progress;
    private const string ProgressKey = "Progress";
    private List<ISaveLoad> _saveLoades = new List<ISaveLoad>();

    public SaveLoadService(IProgressService progress)
    {
      _progress = progress;
      Debug.Log("SaveLoadService Create");
    }

    public void Save()
    {
      Debug.Log("Save");
      foreach (ISaveLoad saveLoad in _saveLoades)
        saveLoad.Save(_progress.PlayerProgress);

      //2ой этап сохранения
      PlayerPrefs.SetString(ProgressKey,_progress.PlayerProgress.ToJson());
      PlayerPrefs.Save();
      //Сохранение в файл.
    }

    public void Load()
    {
        foreach (var saveLoad in _saveLoades)
            saveLoad.Load(_progress.PlayerProgress);
    }

    public PlayerProgress NewProgress()
    {
      _progress.PlayerProgress = new PlayerProgress();
      return _progress.PlayerProgress;
    }

    public void LoadProgressOrInitNew()
    {
      _progress.PlayerProgress =
      LoadProgress()
      ?? NewProgress();
    }

    private PlayerProgress LoadProgress() =>
      PlayerPrefs.GetString(ProgressKey)?
        .ToDeserialized<PlayerProgress>();

    public void AddSaveLoad(ISaveLoad saveLoad)
    {
      if (_saveLoades.Contains(saveLoad))
        return;

      _saveLoades.Add(saveLoad);
      Debug.Log(saveLoad);
    }

    public void Cleanup() =>
      _saveLoades.Clear();
  }
}