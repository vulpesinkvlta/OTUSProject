using Assets.Code.Gameplay.Features.Upgrades.UI;
using System;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardContainer : MonoBehaviour
{
    private IUpgradeFactory _upgradeFactory;
    private List<LevelUpCard> _cards = new List<LevelUpCard>();
    private ICardUIPresenter _cardUIPresenter;

    [Inject]
    public void Construct(ICardUIPresenter cardUIPresenter,
      IUpgradeFactory upgradeFactory)
    {
        _cardUIPresenter = cardUIPresenter;
        _upgradeFactory = upgradeFactory;

        _cardUIPresenter.OnClose += CloseLevelUpWindow;
    }

    public void CreateCards()
    {
        _cards.Add(_upgradeFactory.CreateRandomLevelUpCard(gameObject.transform));
        _cards.Add(_upgradeFactory.CreateRandomLevelUpCard(gameObject.transform));
        _cards.Add(_upgradeFactory.CreateRandomLevelUpCard(gameObject.transform));
    }

    public void DestroyCards()
    {
        for (int i = 0; i < _cards.Count; i++)
            _cards[i].DestroyCard();

        _cards.Clear();
    }

    public void CloseLevelUpWindow()
    {
        DestroyCards();
    }
}