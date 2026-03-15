using Assets.Code.Gameplay.Features.Upgrades.UI;
using Zenject;
using static CardKey;

public class UpgradeSystem : IUpgradeSystem, IInitializable
{
    private readonly IInputService _input;
    private readonly IConfigDataService _config;
    private readonly IPlayerProgressService _player;
    private readonly ICardUIPresenter _presenter;

    public UpgradeSystem(IInputService input, 
            IConfigDataService config,
            IPlayerProgressService player,
            ICardUIPresenter presenter)
    {
        _input = input;
        _config = config;
        _player = player;
        _presenter = presenter;
    }

    public void Initialize()
    {
        _input.OnLevelUpCardClick += LevelUpCard;
    }

    private void LevelUpCard(CardKey cardKey)
    {
        LevelUpCardData cardData = _config.GetCardData(cardKey);  
        switch (cardKey.Id)
        {
            case CardId.Damage:
                _player.UpgradeDamage("BaseTower", cardData.Amount);
                break;
            case CardId.Health:
                _player.UpgradeHealth("BaseTower", cardData.Amount);
                break;
            case CardId.Speed:
                _player.UpgradeFireRate("BaseTower", cardData.Amount); 
                break;
            case CardId.Range:
                _player.UpgradeRange("BaseTower", cardData.Amount);
                break;
        }
        _presenter.Close();
    }
}

