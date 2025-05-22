using Unity.VisualScripting;
using UnityEngine;

public class Card
{
    public CardData Data { get; private set; }

    public Card(CardData data)
    {
        Data = data;
    }

}
