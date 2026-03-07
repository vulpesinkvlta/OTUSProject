using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Code.Infrastructure.Boot
{
  public class Bootstrapper : MonoBehaviour, ICoroutineRunner
  {
    public LoadingCurtain Curtain;
    private Game _game;

    private void Awake()
    {
      // _game = new Game(this, Curtain);
      // _game.StateMachine.Enter<BootstrapState>();
      //
      // DontDestroyOnLoad(this);
    }
  }

  public class Game
  {
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
      // StateMachine = new GameStateMachine(new SceneLoaderService(coroutineRunner), curtain);
    }
  }
}