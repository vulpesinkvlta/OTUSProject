using Code.Infrastructure._Common.Addresses;
using Code.Infrastructure.Installers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.Boot
{
  //Editor_Mode
  public class GameRunner : MonoBehaviour
  {
    private void Awake()
    {
      var bootstrapper = FindObjectOfType<BootstrapInstaller>();

      if (bootstrapper != null) return;

      SceneManager.LoadScene(SceneAddress.Bootstrap);
    }
  }
}