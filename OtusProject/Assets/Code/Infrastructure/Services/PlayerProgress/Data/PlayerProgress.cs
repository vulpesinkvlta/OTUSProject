public class PlayerProgress
{
    public ProgressId ProfileId;
    public PlayerData PlayerData;
    public EnemyData EnemyData;
    public ResourcesData ResourcesData;

    public PlayerProgress()
    {
        PlayerData = new PlayerData();
    }
}