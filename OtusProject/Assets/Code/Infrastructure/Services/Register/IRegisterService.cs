using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.Services.Register
{
  public interface IRegisterService
  {
    void RegisterFromScene(List<MonoBehaviour> monoBehaviours);
  }
}