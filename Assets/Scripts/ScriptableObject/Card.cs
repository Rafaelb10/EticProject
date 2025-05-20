using Unity.VisualScripting;
using UnityEngine;

public class Card
{
    public CardData Data { get; private set; }

    public Card(CardData data)
    {
        Data = data;
    }

    public void Use(PlayerStatus target)
    {
        switch (Data.CardType1)
        {
            case CardData.CardType.Character:
                if (Data.GameObject != null)
                    Object.Instantiate(Data.GameObject);
                break;

            case CardData.CardType.Terrain:
            case CardData.CardType.Effects:
                target.Modify(Data.AttributesTerrain, Data.EffectTypeTerrain);
                break;

            case CardData.CardType.Equipment:
                target.Modify(Data.AttributesEquipment, CardData.EffectType.Gain);
                break;
        }
    }
}
