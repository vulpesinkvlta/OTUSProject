using UnityEngine;
using Zenject;

public class UpgradeFactory : IUpgradeFactory
{
    private readonly IConfigDataService _config;
    private readonly IInstantiator _instantiator;

    public UpgradeFactory(IConfigDataService config, IInstantiator instantiator)
    {
        _config = config;
        _instantiator = instantiator;
    }
    public LevelUpCard CreateRandomLevelUpCard(Transform parent)
    {
        GameObject cardPrefab = Resources.Load<GameObject>("UI/LevelUpCard");
        Debug.Log(cardPrefab);
        LevelUpCard card = _instantiator.InstantiatePrefabForComponent<LevelUpCard>(cardPrefab, parent);
        LevelUpCardData cardData = _config.GetRandomCard();
        card.SetupCard(cardData);
        
        return card;
    }
}