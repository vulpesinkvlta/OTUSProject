using System;

public interface ISceneLoaderService
{
    void Load(string sceneName, Action onLoaded);
}