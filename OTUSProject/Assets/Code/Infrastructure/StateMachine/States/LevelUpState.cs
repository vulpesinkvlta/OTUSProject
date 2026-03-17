using Assets.Code.Gameplay.Features.Upgrades.UI;
using UnityEngine;

namespace Code.Infrastructure.StateMachine.States
{
    public class LevelUpState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ICardUIPresenter _presenter;

        public LevelUpState(IGameStateMachine stateMachine, ICardUIPresenter presenter)
        {
            _stateMachine = stateMachine;
            _presenter = presenter;
        }

        public void Enter()
        {
            Time.timeScale = 0f;
            _presenter.OnClose += OnUpgradeSelected;
            _presenter.Show();
        }

        public void Exit()
        {
            _presenter.OnClose -= OnUpgradeSelected;
            Time.timeScale = 1f;
        }

        private void OnUpgradeSelected()
        {
            _stateMachine.Enter<LevelLoopState>();
        }
    }
}