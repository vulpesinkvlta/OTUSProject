using TMPro;
using UnityEngine;
using Zenject;

public class ExperienceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lvlText;
    [SerializeField] private TextMeshProUGUI _xpText;

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
    }
}
