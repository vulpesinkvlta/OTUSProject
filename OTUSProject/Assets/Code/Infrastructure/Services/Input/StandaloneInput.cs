using System;
using UnityEngine;

public class StandaloneInput : IInputService
{
    public event Action<CardKey> OnLevelUpCardClick;

    public void LevelUpCardClick(CardKey key)
    {
        Debug.Log($"LevelUpCardClick: {key}");
        OnLevelUpCardClick?.Invoke(key);
    }
}