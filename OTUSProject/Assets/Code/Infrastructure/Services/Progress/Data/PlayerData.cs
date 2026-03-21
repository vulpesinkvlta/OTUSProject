using System.Collections.Generic;

namespace Code.Infrastructure.Data
{
  public class PlayerData 
  {
      public int Level;
      public int CurrentXP;
      public List<TowerStatsData> Towers;
      public List<PlacedTowerData> PlacedTowers;

      public PlayerData()
      {
          Level = 1;
          CurrentXP = 0;
          Towers = new List<TowerStatsData>();
          PlacedTowers = new List<PlacedTowerData>();
      }
  }
}