using System;

public interface IInputService
{
    event Action<CardKey> OnLevelUpCardClick;
    void LevelUpCardClick(CardKey key);
}