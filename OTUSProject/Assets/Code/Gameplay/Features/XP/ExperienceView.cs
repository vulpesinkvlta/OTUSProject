using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ExperienceView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI _lvlText;
    [SerializeField] private TextMeshProUGUI _xpText;
    [SerializeField] private Slider _lvlSlider;

    [Inject]
    public void Construct(ExperienceController controller)
    {
    }
    public void SetLevel(int lvl)
    {
        _lvlText.text = lvl.ToString();
    }

    public void SetXP(int xp, int max)
    {
        _xpText.text = $"{xp} / {max}";
        _lvlSlider.maxValue = max;
        _lvlSlider.value = xp;
    }
}
