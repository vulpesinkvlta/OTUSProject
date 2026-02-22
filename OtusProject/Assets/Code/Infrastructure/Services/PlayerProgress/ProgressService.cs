using System.Collections.Generic;
public class ProgressService : IProgressService
{
    public PlayerProgress PlayerProgress { get; set; }
    public CommonData CommonData { get; set; }
    public Dictionary<ProgressId, PlayerProgress> Profiles { get; set; }

    public ProgressService()
    {
    }

    public void SetProfile()
    {

    }
}

public enum ProgressId
{
    None = 0,
    Profile1 = 1,
    Profile2 = 2,
    Profile3 = 3
}
