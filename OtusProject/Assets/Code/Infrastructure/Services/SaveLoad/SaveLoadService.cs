using System.Collections.Generic;
using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private readonly IProgressService _progress;
    private const string ProgressKey = "Progress";
    private List<ISaveLoad> saveLoades = new List<ISaveLoad>();

    public SaveLoadService(IProgressService progress)
    {
        _progress = progress;
        Debug.Log("SaveLoadService Create");
    }

    public void Save()
    {
        Debug.Log("Save");
        foreach (ISaveLoad saveLoad in saveLoades)
            saveLoad.Save(_progress.PlayerProgress);

        //2ой этап сохранения
        PlayerPrefs.SetString(ProgressKey, _progress.PlayerProgress.ToJson());

        //Сохранение в файл.
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
        saveLoades.Add(saveLoad);
        Debug.Log(saveLoad);
    }

    public void Cleanup() =>
      saveLoades.Clear();
}