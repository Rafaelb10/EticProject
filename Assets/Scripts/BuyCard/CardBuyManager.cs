using UnityEngine;
using UnityEngine.Events;

public class CardBuyManager : MonoBehaviour
{
    [SerializeField] private CardManager _cardmanager;

    public void BuyEffect()
    {
        _cardmanager.BuyCard(0);
        _cardmanager.GenerateCard();
        _cardmanager.PlaceCard();
    }
    public void BuyCharacter()
    {
        _cardmanager.BuyCard(1);
        _cardmanager.GenerateCard();
        _cardmanager.PlaceCard();
    }

    public void BuyTerrain()
    {
        _cardmanager.BuyCard(2);
        _cardmanager.GenerateCard();
        _cardmanager.PlaceCard();
    }

    public void BuyEquipment()
    {
        _cardmanager.BuyCard(3);
        _cardmanager.GenerateCard();
        _cardmanager.PlaceCard();
    }
}
