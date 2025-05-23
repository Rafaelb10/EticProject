using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardData> possibleCards;

    private List<Card> _characterInHand = new List<Card>();
    private List<Card> _effectInHand = new List<Card>();
    private List<Card> _terrainInHand = new List<Card>();
    private List<Card> _equipamentInHand = new List<Card>();

    private const int _characterInHandLimit = 5;
    private const int _effectInHandLimit = 2;
    private const int _terrainInHandLimit = 2;
    private const int _equipamentInHandLimit = 3;

    private Card _insuredCard;
    private bool _haveCard = false;

    [SerializeField] private List<Transform> _characterSlot = new List<Transform>();
    [SerializeField] private List<Transform> _effectSlot = new List<Transform>();
    [SerializeField] private List<Transform> _terraintSlot = new List<Transform>();
    [SerializeField] private List<Transform> _equipamentSlot = new List<Transform>();


    [SerializeField] private CardView cardViewPrefabEffect;
    [SerializeField] private CardView cardViewPrefabCharacter;
    [SerializeField] private CardView cardViewPrefabTerrain;
    [SerializeField] private CardView cardViewPrefabEquipament;

    private PoolManager<CardView> _cardViewPoolEffect;
    private PoolManager<CardView> _cardViewPoolCharacter;
    private PoolManager<CardView> _cardViewPoolTerrain;
    private PoolManager<CardView> _cardViewPoolEquipament;

    private int _buy;

    public Card InsuredCard { get => _insuredCard; set => _insuredCard = value; }
    public bool HaveCard { get => _haveCard; set => _haveCard = value; }

    private void Start()
    {
        _cardViewPoolEffect = new PoolManager<CardView>(cardViewPrefabEffect, 10);
        _cardViewPoolCharacter = new PoolManager<CardView>(cardViewPrefabCharacter, 10);
        _cardViewPoolTerrain = new PoolManager<CardView>(cardViewPrefabTerrain, 10);
        _cardViewPoolEquipament = new PoolManager<CardView>(cardViewPrefabEquipament, 10);
    }

    public void BuyCard(int value)
    {
        _buy = value;
    }

    public void GenerateCard()
    {
        if (possibleCards.Count == 0) return;

        List<CardData> filtered = null;
        List<Card> targetList = null;
        int limit = 0;

        switch (_buy)
        {
            case 0:
                filtered = possibleCards.FindAll(c => c.CardType1 == CardData.CardType.Effects);
                targetList = _effectInHand;
                limit = _effectInHandLimit;
                break;
            case 1:
                filtered = possibleCards.FindAll(c => c.CardType1 == CardData.CardType.Character);
                targetList = _characterInHand;
                limit = _characterInHandLimit;
                break;
            case 2:
                filtered = possibleCards.FindAll(c => c.CardType1 == CardData.CardType.Terrain);
                targetList = _terrainInHand;
                limit = _terrainInHandLimit;
                break;
            case 3:
                filtered = possibleCards.FindAll(c => c.CardType1 == CardData.CardType.Equipment);
                targetList = _equipamentInHand;
                limit = _equipamentInHandLimit;
                break;
        }

        if (filtered == null || filtered.Count == 0) return;

        int index = Random.Range(0, filtered.Count);
        Card newCard = new Card(filtered[index]);

        if (targetList.Count >= limit)
        {
            targetList.RemoveAt(Random.Range(0, targetList.Count));
        }

        targetList.Add(newCard);
    }

    public void PlaceCard()
    {
        PlaceCardsInSlots(_effectInHand, _effectSlot);
        PlaceCardsInSlots(_characterInHand, _characterSlot);
        PlaceCardsInSlots(_terrainInHand, _terraintSlot);
        PlaceCardsInSlots(_equipamentInHand, _equipamentSlot);
    }

    private void PlaceCardsInSlots(List<Card> hand, List<Transform> slots)
    {
        for (int i = 0; i < hand.Count && i < slots.Count; i++)
        {
            if (slots[i].childCount == 0)
            {
                Card card = hand[i];
                CardView view = null;

                switch (card.Data.CardType1)
                {
                    case CardData.CardType.Character:
                        view = _cardViewPoolCharacter.Get();
                        break;
                    case CardData.CardType.Effects:
                        view = _cardViewPoolEffect.Get();
                        break;
                    case CardData.CardType.Terrain:
                        view = _cardViewPoolTerrain.Get();
                        break;
                    case CardData.CardType.Equipment:
                        view = _cardViewPoolEquipament.Get();
                        break;
                }

                if (view != null)
                {
                    view.transform.SetParent(slots[i], false);
                    view.Setup(card);
                    view.Index = i;
                }
            }
        }
    }

    public void SelectCard(int index, CardData.CardType cardType)
    {
        switch (cardType)
        {
            case CardData.CardType.Character:
                InsuredCard = _characterInHand[index];
                break;
            case CardData.CardType.Effects:
                InsuredCard = _effectInHand[index];
                break;
            case CardData.CardType.Terrain:
                InsuredCard = _terrainInHand[index];
                break;
            case CardData.CardType.Equipment:
                InsuredCard = _equipamentInHand[index];
                break;
        }

        HaveCard = true;
    }

    public void RemoveCard()
    {
        if (InsuredCard == null) return;

        List<Card> targetList = null;
        List<Transform> slotList = null;

        switch (InsuredCard.Data.CardType1)
        {
            case CardData.CardType.Character:
                targetList = _characterInHand;
                slotList = _characterSlot;
                break;
            case CardData.CardType.Effects:
                targetList = _effectInHand;
                slotList = _effectSlot;
                break;
            case CardData.CardType.Terrain:
                targetList = _terrainInHand;
                slotList = _terraintSlot;
                break;
            case CardData.CardType.Equipment:
                targetList = _equipamentInHand;
                slotList = _equipamentSlot;
                break;
        }

        if (targetList != null && slotList != null)
        {
            int index = targetList.IndexOf(InsuredCard);
            if (index >= 0 && index < slotList.Count && slotList[index].childCount > 0)
            {
                Transform child = slotList[index].GetChild(0);
                CardView view = child.GetComponent<CardView>();
                if (view != null)
                {
                    switch (InsuredCard.Data.CardType1)
                    {
                        case CardData.CardType.Character:
                            _cardViewPoolCharacter.ReturnToPool(view);
                            break;
                        case CardData.CardType.Effects:
                            _cardViewPoolEffect.ReturnToPool(view);
                            break;
                        case CardData.CardType.Terrain:
                            _cardViewPoolTerrain.ReturnToPool(view);
                            break;
                        case CardData.CardType.Equipment:
                            _cardViewPoolEquipament.ReturnToPool(view);
                            break;
                    }
                }
            }

            targetList.RemoveAt(index);
        }

        InsuredCard = null;
        HaveCard = false;
    }
}
