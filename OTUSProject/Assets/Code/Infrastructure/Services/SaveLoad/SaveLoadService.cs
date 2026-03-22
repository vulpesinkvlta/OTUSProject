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
    private readonly List<ISaveLoad> _saveLoades = new();

    public SaveLoadService(IProgressService progress)
    {
      _progress = progress;
      Debug.Log("SaveLoadService Create");
    }

    public void Save()
    {
      EnsureProgress();
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
        EnsureProgress();
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
      //_progress.PlayerProgress =
      //LoadProgress()
      //?? NewProgress();
      _progress.PlayerProgress = Sanitize(LoadProgress()) ?? NewProgress();
    }

    private PlayerProgress LoadProgress()
    {
      string rawProgress = PlayerPrefs.GetString(ProgressKey, string.Empty);
      if (string.IsNullOrWhiteSpace(rawProgress))
        return null;

      return rawProgress.ToDeserialized<PlayerProgress>();
    }

    public void AddSaveLoad(ISaveLoad saveLoad)
    {
      if (_saveLoades.Contains(saveLoad))
        return;

      _saveLoades.Add(saveLoad);
      Debug.Log(saveLoad);
    }

    public void Cleanup() =>
      _saveLoades.Clear();
    private void EnsureProgress()
    {
        _progress.PlayerProgress = Sanitize(_progress.PlayerProgress) ?? new PlayerProgress();
    }

    private static PlayerProgress Sanitize(PlayerProgress progress)
    {
        if (progress == null)
            return null;

        progress.PlayerData ??= new PlayerData();
        progress.EnemyData ??= new EnemyData();
        progress.InventoryData ??= new InventoryData();
        progress.ResourcesData ??= new ResourcesData();
        progress.CommonData ??= new CommonData();
        progress.PlayerData.Towers ??= new List<TowerStatsData>();
        progress.PlayerData.PlacedTowers ??= new List<PlacedTowerData>();
        return progress;
    }
    }
}