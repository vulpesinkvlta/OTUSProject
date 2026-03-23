using Code.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ClearSaveProgress : MonoBehaviour
{
    [Inject] private ISaveLoadService _saveLoad;

    public void OnClick()
    {
        _saveLoad.ClearProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

