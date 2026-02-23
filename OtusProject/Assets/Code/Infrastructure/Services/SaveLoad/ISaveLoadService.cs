using Code.Infrastructure.Data;

namespace Code.Infrastructure.Services.SaveLoad
{
  public interface ISaveLoadService
  {
    void AddSaveLoad(ISaveLoad saveLoad);
    void Cleanup();
    void Save();
    PlayerProgress NewProgress();
    void LoadProgressOrInitNew();
    void Load();
    }
}