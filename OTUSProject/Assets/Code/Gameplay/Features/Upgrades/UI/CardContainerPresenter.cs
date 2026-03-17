using System;

namespace Assets.Code.Gameplay.Features.Upgrades.UI
{
    public class CardContainerPresenter : ICardUIPresenter
    {
        public event Action OnShow;
        public event Action OnClose;

        public void Show() => OnShow?.Invoke();
        public void Close() => OnClose?.Invoke();
    }
}
