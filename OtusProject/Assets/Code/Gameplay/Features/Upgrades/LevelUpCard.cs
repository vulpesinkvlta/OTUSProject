using TMPro;

using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class LevelUpCard : MonoBehaviour
{
    [SerializeField] private Button _clickButton;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _lableText;
    [SerializeField] private TextMeshProUGUI _discriptionText;
    private CardKey _cardKey;
    private IInputService _input;
    [Inject]
    public void Construct(IInputService input)
    {
        _input = input;
    }

    
    private void Start() =>
        _clickButton.onClick.AddListener(Click);

    public void SetupCard(LevelUpCardData levelUpCardData)
    {
        _icon.sprite = levelUpCardData.Icon;
        _icon.color = levelUpCardData.IconColor;
        Color color = _icon.color;
        color.a = 1f;
        _icon.color = color;
        _lableText.text = levelUpCardData.LabelName;
        _cardKey = levelUpCardData.CardKey;
        _discriptionText.text = levelUpCardData.Amount.ToString(); ;
    }

    private void Click()
    {
        _input.LevelUpCardClick(_cardKey);
    }

    public void DestroyCard() =>
        Destroy(gameObject);
}
