using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Gameplay.Features.Upgrades.UI
{
    public class CardContainerPresenter : ICardUIPresenter
    {
        public event Action OnClose;

        public void Close()=> OnClose?.Invoke();
    }
}
