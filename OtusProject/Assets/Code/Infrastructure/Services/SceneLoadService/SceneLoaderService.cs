using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderService : ISceneLoaderService
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoaderService(ICoroutineRunner coroutineRunner) =>
      _coroutineRunner = coroutineRunner;

    public void Load(string name, Action OnLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadScene(name, OnLoaded));
    }

    private IEnumerator LoadScene(string name, Action onLoaded = null)
    {
        // if (SceneManager.GetActiveScene().name == name)
        // {
        //   onLoaded?.Invoke();
        //   yield break;
        // }
        //
        AsyncOperation waitScene = SceneManager.LoadSceneAsync(name);

        while (!waitScene.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}