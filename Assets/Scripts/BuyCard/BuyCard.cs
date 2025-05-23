using UnityEngine;

public class BuyCard : MonoBehaviour, IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;

    [SerializeField] private int _cardIndexToBuy = 0;
    [SerializeField] private CardBuyManager _cardBuyManager;

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
        CameraPlayer cameraPlayer = FindAnyObjectByType<CameraPlayer>();
        if (_cardIndexToBuy == 0)
        {
            _cardBuyManager.BuyEffect();
        }
        else if (_cardIndexToBuy == 1)
        {
            _cardBuyManager.BuyCharacter();
        }
        else if (_cardIndexToBuy == 2)
        {
            _cardBuyManager.BuyTerrain();
        }
        else if (_cardIndexToBuy == 3)
        {
            _cardBuyManager.BuyEquipment();
        }
        ResetColor();
        cameraPlayer.StopInterect();
    }

    public void PossibleToInterect()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Color baseColor = renderer.material.GetColor("_BaseColor");
            Color bluish = new Color(baseColor.r * 0.8f, baseColor.g * 0.8f, 1f, baseColor.a);
            renderer.material.SetColor("_BaseColor", bluish);
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
