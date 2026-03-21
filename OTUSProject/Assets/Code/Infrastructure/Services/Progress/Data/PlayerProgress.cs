using Code.Infrastructure.Services.Progress;

namespace Code.Infrastructure.Data
{
  public class PlayerProgress
  {
    //public ProgressId ProfileId;
    //public PlayerData PlayerData;
    //public EnemyData EnemyData;
    //public InventoryData InventoryData;
    //public ResourcesData ResourcesData;
    public ExperienceService ExperienceService;
    public TowerStats TowerStats;
    public IProgressService ProgressService;
        public PlayerProgress()
    {
        //PlayerData = new PlayerData();
        ExperienceService = new ExperienceService(ProgressService); 
        TowerStats = new TowerStats(ProgressService);  
     }
  }
}