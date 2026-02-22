using System.Collections.Generic;
using Code.Infrastructure._Common.Abstractions;
using Code.Infrastructure.Services.Register;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Gameplay.Features.Scene
{
  public class SceneScanService : MonoBehaviour
  {
    private IRegisterService _register;

    [Inject]
    public void Construct(IRegisterService register)
    {
      _register = register;
    }

    private void Awake()
    {
      Debug.Log("SceneScan Awake");
      Scan();
    }

    public List<MonoBehaviour> ColletAll()
    {
      var activeScene = SceneManager.GetActiveScene();
      var list = new List<MonoBehaviour>();

      var all = FindObjectsOfType<MonoBehaviour>();

      foreach (var monoBehaviour in all)
      {
        if (monoBehaviour is IMyReflection reflection)
        {
          Debug.Log(monoBehaviour.name);
          list.Add(monoBehaviour);
        }
      }

      return list;
    }

    public void Scan()
    {
      _register.RegisterFromScene(ColletAll());
    }
  }
}