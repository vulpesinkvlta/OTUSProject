using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Features.Upgrades.UI
{
    public class LevelUpWindow : MonoBehaviour
    {
        [SerializeField] private CardContainer _cardContainer;

        private ICardUIPresenter _presenter;

        [Inject]
        public void Construct(ICardUIPresenter presenter)
        {
            _presenter = presenter;

            _presenter.OnClose += CloseWindow;
        }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void ShowLevelUpWindow()
        {
            gameObject.SetActive(true);
            _cardContainer.CreateCards();
        }

        private void CloseWindow()
        {
            _cardContainer.DestroyCards();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _presenter.OnClose -= CloseWindow;
        }
    }
}
