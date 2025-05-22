using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;

    private Image _cardArt;
    private TMP_Text _nameCard;
    private TMP_Text _descriptionCard;

    private GameObject _cardArtBattle;

    [SerializeField] private int _cardType;

    private int _index;

    private bool _used;

    public int Index { get => _index; set => _index = value; }
    public bool Used { get => _used; set => _used = value; }
    public GameObject CardArtBattle { get => _cardArtBattle; set => _cardArtBattle = value; }

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            _materialInstance = renderer.material;
            _originalColor = _materialInstance.GetColor("_BaseColor");
        }
    }

    public void Setup(Card card)
    {
        _cardType = (int)card.Data.CardType1;
        CardArtBattle = card.Data.GameObjectCard2;
        //    _cardArt.sprite = card.Data.SpriteCard;
        //    _nameCard.text = card.Data.Name;
        //    _descriptionCard.text = card.Data.Description;
    }
    public void Interect()
    {
        if (_used == false)
        {
            CameraPlayer cameraPlayer = FindAnyObjectByType<CameraPlayer>();
            CardManager cardManager = FindAnyObjectByType<CardManager>();

            cardManager.SelectCard(_index, (CardData.CardType)_cardType);
            cameraPlayer.StopInterect();
            ResetColor();
        }

    }

    public void PossibleToInterect()
    {
        if (_used == false)
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
