using Code.Infrastructure.Data;

namespace Code.Infrastructure.Services.SaveLoad
{
  public interface ISaveLoad
  {
    public void Save(PlayerProgress progress);
    public void Load(PlayerProgress progress);
  }
}