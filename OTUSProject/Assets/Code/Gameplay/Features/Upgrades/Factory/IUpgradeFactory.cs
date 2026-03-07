using UnityEngine;

public interface IUpgradeFactory
{
    LevelUpCard CreateRandomLevelUpCard(Transform parent);
}