using Assets.Code.Gameplay.Features.Upgrades.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Button _upgButton;
    [SerializeField] private LevelUpWindow _levelUpWindow;
    public event Action OnUpgradePlayer;
    public event Action OnUpgradeGold;

    private void Start()
    {
        _upgButton.onClick.AddListener(CreateCards);
    }

    private void CreateCards()
    {
        _levelUpWindow.ShowLevelUpWindow();
    }
}
