using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardData> possibleCards;
    private List<Card> CharacterInHand = new List<Card>();
    private List<Card> EffectInHand = new List<Card>();
    private List<Card> TerrainInHand = new List<Card>();
    private List<Card> EquipamentInHand = new List<Card>();

    private const int CharacterInHandLimit = 5;
    private const int EffectInHandLimit = 2;
    private const int TerrainInHandLimit = 2;
    private const int EquipamentInHandLimit = 3;



    public void GenerateRandomCard()
    {
        if (possibleCards.Count == 0)
        {
            Debug.LogWarning("No cards available.");
            return;
        }

        // Escolher uma aleatória
        int index = Random.Range(0, possibleCards.Count);
        Card newCard = new Card(possibleCards[index]);

        // Se a mão estiver cheia, remover uma aleatória
        if (CharacterInHand.Count >= CharacterInHandLimit)
        {
            int removeIndex = Random.Range(0, CharacterInHand.Count);
            Debug.Log($"Discarding card at index {removeIndex}");
            CharacterInHand.RemoveAt(removeIndex);
        }

        CharacterInHand.Add(newCard);
        Debug.Log($"Added card: {newCard.Data.name}");
    }

    public void UseCard(int index, PlayerStatus player)
    {
        if (index < 0 || index >= hand.Count) return;

        Card card = hand[index];
        card.Use(player);
        hand.RemoveAt(index);
    }
}
