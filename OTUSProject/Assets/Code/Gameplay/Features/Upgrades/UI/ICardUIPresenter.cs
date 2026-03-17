using System;

namespace Assets.Code.Gameplay.Features.Upgrades.UI
{
    public interface ICardUIPresenter
    {
        event Action OnShow;
        event Action OnClose;

        void Show();
        void Close();
    }
}