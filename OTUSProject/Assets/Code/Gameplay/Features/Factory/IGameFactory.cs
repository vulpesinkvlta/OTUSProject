using UnityEngine;

namespace Code.Gameplay.Features.Factory
{
  public interface IGameFactory
  {
    void CreatePlayer(Vector3 position);
  }
}