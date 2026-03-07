public interface IConfigDataService
{
    LevelUpCardData GetCardData(CardKey cardKey);
    LevelUpCardData GetRandomCard();
    void Load();
}