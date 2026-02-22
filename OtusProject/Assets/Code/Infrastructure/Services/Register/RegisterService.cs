using System.Collections.Generic;
using Code.Infrastructure.Contexts;
using UnityEngine;

namespace Code.Infrastructure.Services.Register
{
  public class RegisterService : IRegisterService
  {
    private readonly GameLayerContext _game;

    public RegisterService(GameLayerContext game)
    {
      _game = game;
    }

    public void RegisterFromScene(List<MonoBehaviour> monobehs)
    {
      foreach (var mb in monobehs) 
        _game.AddReflection(mb);
    }

    public void RegisterFromGameObjectContext()
    {
      
    }
  }
}