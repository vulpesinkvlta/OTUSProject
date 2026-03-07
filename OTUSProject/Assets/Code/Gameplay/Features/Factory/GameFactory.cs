using Code.Infrastructure.Services.Register;
using Code.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Code.Gameplay.Features.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly ISaveLoadService _saveLoad;
    private readonly IRegisterService _register;

    public GameFactory(ISaveLoadService saveLoad,
      IRegisterService register)
    {
      _saveLoad = saveLoad;
      _register = register;
    }

    public void CreatePlayer(Vector3 position)
    {
      //GameObject playerPrefab = Resources.Load<GameObject>("Player");
      //GameObject playerObject = GameObject.Instantiate(playerPrefab, position, Quaternion.identity);
        Debug.Log("Player created");
      //PlayerInstaller player = playerObject.GetComponent<PlayerInstaller>();
     // _saveLoad.AddSaveLoad(player.PlayerHealth as ISaveLoad);
      // _register.RegisterFromScene();
    }
    
    public void CreateEnemy(EnemyId enemyId, Vector3 position)
    {
      
    }

    public void CreateUI()
    {
      
    }
  }

  public enum EnemyId
  {
    None = 0,
    Golem = 1,
    Skeleton = 2,
  }
}