using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IInterectable
{
    private Image _cardArt;
    private TMP_Text _nameCard;
    private TMP_Text _descriptionCard;

    public void Setup(Card card)
    {
        _cardArt.sprite = card.Data.SpriteCard;
        _nameCard.text = card.Data.Name;
        _descriptionCard.text = card.Data.Description;
    }
    public void Interect()
    {
        
    }
}
