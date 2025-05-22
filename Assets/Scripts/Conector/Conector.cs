using System;
using UnityEngine;
using static CardData;

public class Conector : MonoBehaviour, IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;
    [SerializeField] private Transform _transformSpaw;
    [SerializeField] private BoardGame _spawCard;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            _materialInstance = renderer.material;
            _originalColor = _materialInstance.GetColor("_BaseColor");
        }
    }


    public void Interect()
    {
        CardManager cardManager = FindAnyObjectByType<CardManager>();

        if (cardManager.HaveCard)
        {
            
            if (cardManager.InsuredCard != null)
            {
                switch (cardManager.InsuredCard.Data.CardType1)
                {
                    case CardData.CardType.Character:
                        GameObject CardView1 = Instantiate(cardManager.InsuredCard.Data.GameObjectCard, _transformSpaw);
                        CardView1.GetComponent<CardView>().Setup(cardManager.InsuredCard);
                        CardView1.GetComponent<CardView>().Used = true;
                        _spawCard.ObjectInThisPlace = Instantiate(cardManager.InsuredCard.Data.GameObjectCard2);
                        _spawCard.HaveObject = true;

                        cardManager.RemoveCard();
                        
                        break;
                    case CardData.CardType.Effects:
                        GameObject CardView2 = Instantiate(cardManager.InsuredCard.Data.GameObjectCard, _transformSpaw);
                        CardView2.GetComponent<CardView>().Setup(cardManager.InsuredCard);
                        CardView2.GetComponent<CardView>().Used = true;

                        cardManager.RemoveCard();

                        break;
                    case CardData.CardType.Terrain:
                        GameObject CardView3 = Instantiate(cardManager.InsuredCard.Data.GameObjectCard, _transformSpaw);
                        CardView3.GetComponent<CardView>().Setup(cardManager.InsuredCard);
                        CardView3.GetComponent<CardView>().Used = true;

                        cardManager.RemoveCard();

                        break;
                    case CardData.CardType.Equipment:
                        GameObject CardView4 = Instantiate(cardManager.InsuredCard.Data.GameObjectCard, _transformSpaw);
                        CardView4.GetComponent<CardView>().Setup(cardManager.InsuredCard);
                        CardView4.GetComponent<CardView>().Used = true;

                        cardManager.RemoveCard();

                        break;
                }
            } 
        }
    }


    public void PossibleToInterect()
    {
        CardManager cardManager = FindAnyObjectByType<CardManager>();

        if (cardManager.HaveCard)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                Color baseColor = renderer.material.GetColor("_BaseColor");
                Color bluish = new Color(baseColor.r * 0.8f, baseColor.g * 0.8f, 1f, baseColor.a);
                renderer.material.SetColor("_BaseColor", bluish);
            }
        }
    }

    public void ResetColor()
    {
        if (_materialInstance != null)
        {
            _materialInstance.SetColor("_BaseColor", _originalColor);
        }
    }
}
