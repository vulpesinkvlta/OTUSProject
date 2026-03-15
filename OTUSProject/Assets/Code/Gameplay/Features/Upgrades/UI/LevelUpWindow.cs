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
        private IExperienceService _experienceService;

        [Inject]
        public void Construct(ICardUIPresenter presenter, IExperienceService experienceService)
        {
            _presenter = presenter;
            _experienceService = experienceService;
            _presenter.OnClose += CloseWindow;
        }

        private void Awake()
        {
            gameObject.SetActive(false);
            _experienceService.OnLevelChanged += ShowLevelUpWindow;
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
            _experienceService.OnLevelChanged -= ShowLevelUpWindow;
        }
    }
}
