using Code.Infrastructure.Services.Progress;

namespace Code.Infrastructure.Data
{
  public class PlayerProgress
  {
    public ProgressId ProfileId;
    public PlayerData PlayerData;
    public EnemyData EnemyData;
    public InventoryData InventoryData;
    public ResourcesData ResourcesData;

    public PlayerProgress()
    {
      PlayerData = new PlayerData();
    }
  }
}