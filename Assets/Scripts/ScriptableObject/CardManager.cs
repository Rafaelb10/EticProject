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

    private int _buy;

    public Card InsuredCard { get => _insuredCard; set => _insuredCard = value; }
    public bool HaveCard { get => _haveCard; set => _haveCard = value; }

    private void Start()
    {
        BuyCard(1);
        GenerateCard();
        PlaceCard();
    }

    public void BuyCard(int value)
    {
        _buy = value;
    }

    public void GenerateCard()
    {
        if (possibleCards.Count == 0)
        {
            return;
        }
        else
        {
            if (_buy == 0)
            {
                List<CardData> effectsCards = possibleCards.FindAll(card => card.CardType1 == CardData.CardType.Effects);

                if (effectsCards.Count == 0)
                {
                    return;
                }

                int index = Random.Range(0, effectsCards.Count);
                Card newCard = new Card(effectsCards[index]);

                if (_effectInHand.Count >= _effectInHandLimit)
                {
                    int removeIndex = Random.Range(0, _effectInHand.Count);
                    _effectInHand.RemoveAt(removeIndex);
                }

                _effectInHand.Add(newCard);
            }

            if (_buy == 1)
            {
                List<CardData> characterCards = possibleCards.FindAll(card => card.CardType1 == CardData.CardType.Character);

                if (characterCards.Count == 0)
                {
                    return;
                }

                int index = Random.Range(0, characterCards.Count);
                Card newCard = new Card(characterCards[index]);

                if (_characterInHand.Count >= _characterInHandLimit)
                {
                    int removeIndex = Random.Range(0, _characterInHand.Count);
                    _characterInHand.RemoveAt(removeIndex);
                }

                _characterInHand.Add(newCard);
            }

            if (_buy == 2)
            {
                List<CardData> terrainCards = possibleCards.FindAll(card => card.CardType1 == CardData.CardType.Terrain);

                if (terrainCards.Count == 0)
                {
                    return;
                }

                int index = Random.Range(0, terrainCards.Count);
                Card newCard = new Card(terrainCards[index]);

                if (_terrainInHand.Count >= _terrainInHandLimit)
                {
                    int removeIndex = Random.Range(0, _terrainInHand.Count);
                    _terrainInHand.RemoveAt(removeIndex);
                }

                _terrainInHand.Add(newCard);
            }

            if (_buy == 3)
            {
                List<CardData> equipamentCards = possibleCards.FindAll(card => card.CardType1 == CardData.CardType.Equipment);

                if (equipamentCards.Count == 0)
                {
                    return;
                }

                int index = Random.Range(0, equipamentCards.Count);
                Card newCard = new Card(equipamentCards[index]);

                if (_equipamentInHand.Count >= _equipamentInHandLimit)
                {
                    int removeIndex = Random.Range(0, _equipamentInHand.Count);
                    _equipamentInHand.RemoveAt(removeIndex);
                }

                _equipamentInHand.Add(newCard);
            }
        }

    }

    public void PlaceCard()
    {
        for (int i = 0; i < _effectInHand.Count && i < _effectSlot.Count; i++)
        {
            if (_effectSlot[i].childCount == 0)
            {
                GameObject CardView = Instantiate(_effectInHand[i].Data.GameObjectCard, _effectSlot[i]);
                CardView.GetComponent<CardView>().Setup(_effectInHand[i]);
                CardView.GetComponent<CardView>().Index = i;
            }
        }

        for (int i = 0; i < _characterInHand.Count && i < _characterSlot.Count; i++)
        {
            if (_characterSlot[i].childCount == 0) 
            {
                GameObject CardView = Instantiate(_characterInHand[i].Data.GameObjectCard, _characterSlot[i]);
                CardView.GetComponent<CardView>().Setup(_characterInHand[i]);
                CardView.GetComponent<CardView>().Index = i;
            }
        }

        for (int i = 0; i < _terrainInHand.Count && i < _terraintSlot.Count; i++)
        {
            if (_terraintSlot[i].childCount == 0)
            {
                GameObject CardView = Instantiate(_terrainInHand[i].Data.GameObjectCard, _terraintSlot[i]);
                CardView.GetComponent<CardView>().Setup(_terrainInHand[i]);
                CardView.GetComponent<CardView>().Index = i;
            }
        }

        for (int i = 0; i < _equipamentInHand.Count && i < _equipamentSlot.Count; i++)
        {
            if (_equipamentSlot[i].childCount == 0)
            {
                GameObject CardView = Instantiate(_equipamentInHand[i].Data.GameObjectCard, _equipamentSlot[i]);
                CardView.GetComponent<CardView>().Setup(_equipamentInHand[i]);
                CardView.GetComponent<CardView>().Index = i;
            }
        }
    }

    public void SelectCard(int index, CardData.CardType cardType)
    {
        switch (cardType)
        {
            case CardData.CardType.Character:
                InsuredCard = _characterInHand[index];
                HaveCard = true;
                break;
            case CardData.CardType.Effects:
                InsuredCard = _effectInHand[index];
                HaveCard = true;
                break;
            case CardData.CardType.Terrain:
                InsuredCard = _terrainInHand[index];
                HaveCard = true;
                break;
            case CardData.CardType.Equipment:
                HaveCard = true;
                InsuredCard = _equipamentInHand[index];
                break;
        }
    }

    public void RemoveCard()
    {
        if (InsuredCard != null)
        {
            List<Card> listToRemoveFrom = null;
            List<Transform> slotList = null;

            switch (InsuredCard.Data.CardType1)
            {
                case CardData.CardType.Character:
                    listToRemoveFrom = _characterInHand;
                    slotList = _characterSlot;
                    break;
                case CardData.CardType.Effects:
                    listToRemoveFrom = _effectInHand;
                    slotList = _effectSlot;
                    break;
                case CardData.CardType.Terrain:
                    listToRemoveFrom = _terrainInHand;
                    slotList = _terraintSlot;
                    break;
                case CardData.CardType.Equipment:
                    listToRemoveFrom = _equipamentInHand;
                    slotList = _equipamentSlot;
                    break;
            }

            if (listToRemoveFrom != null && slotList != null)
            {
                int index = listToRemoveFrom.IndexOf(InsuredCard);
                if (index >= 0 && index < slotList.Count)
                {
                    if (slotList[index].childCount > 0)
                    {
                        Transform child = slotList[index].GetChild(0);
                        Destroy(child.gameObject);
                    }

                    listToRemoveFrom.RemoveAt(index);
                }
            }

            InsuredCard = null;
            HaveCard = false;
        }

        InsuredCard = null;
        HaveCard = false;
    }
}
