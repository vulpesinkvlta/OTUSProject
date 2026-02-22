using System;

namespace Assets.Code.Gameplay.Features.Upgrades.UI
{
    public interface ICardUIPresenter
    {
        event Action OnClose;

        void Close();
    }
}