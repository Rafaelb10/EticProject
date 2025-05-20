using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardData> possibleCards;
    private List<Card> hand = new List<Card>();
    private const int handLimit = 5;

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
        if (hand.Count >= handLimit)
        {
            int removeIndex = Random.Range(0, hand.Count);
            Debug.Log($"Discarding card at index {removeIndex}");
            hand.RemoveAt(removeIndex);
        }

        hand.Add(newCard);
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
