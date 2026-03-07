using Assets.Code.Gameplay.Features.Upgrades.UI;
using Zenject;
using static CardKey;

public class UpgradeSystem : IUpgradeSystem, IInitializable
{
    private readonly IInputService _input;
    private readonly IConfigDataService _config;
   // private readonly IPlayerService _player;
    private readonly ICardUIPresenter _presenter;

    public UpgradeSystem(IInputService input, 
            IConfigDataService config, 
         //   IPlayerService player,
            ICardUIPresenter presenter)
    {
        _input = input;
        _config = config;
       // _player = player;
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
                break;
            case CardId.Health:
              //  _player.GetPlayer().PlayerHealthMono.UpgradeHealth(cardData.Amount);
                break;
            case CardId.Speed:
                break;
        }

        _presenter.Close();
    }
}

