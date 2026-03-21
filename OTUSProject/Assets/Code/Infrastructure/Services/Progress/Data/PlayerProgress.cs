using Code.Infrastructure.Services.Progress;
using System;

namespace Code.Infrastructure.Data
{
  [Serializable]
  public class PlayerProgress
  {
        public PlayerData PlayerData;
        public EnemyData EnemyData;
        public InventoryData InventoryData;
        public ResourcesData ResourcesData;
        public CommonData CommonData;

        public PlayerProgress()
        {
            PlayerData = new PlayerData();
            EnemyData = new EnemyData();
            InventoryData = new InventoryData();
            ResourcesData = new ResourcesData();
            CommonData = new CommonData();
        }
  }
}