using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ConfigDataService : IConfigDataService
{
    private Dictionary<CardKey, LevelUpCardData> _cards = new();

    public void Load()
    {
        _cards = Resources.LoadAll<LevelUpCardData>("Configs/Cards")
            .ToDictionary(x => x.CardKey, x => x);

        foreach(KeyValuePair<CardKey, LevelUpCardData> kv in _cards)
        {
            Debug.Log(kv.Key.Id);
        }
    }

    public LevelUpCardData GetCardData(CardKey cardKey) =>
        _cards.TryGetValue(cardKey, out var config)
        ? config : null;

    public Dictionary<CardKey, LevelUpCardData> GetAllCards() => _cards;

    public LevelUpCardData GetRandomCard()
    {
        if (_cards.Count == 0)
        {
            Debug.LogWarning("Config dictionary is empty!");
            return null;
        }

        int index = Random.Range(0, _cards.Count);
        var randomElement = _cards.ElementAt(index);
        return GetCardData(randomElement.Key);
    }
}

