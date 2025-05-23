using UnityEngine;

public class BuyCardShow : MonoBehaviour , IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;

    [SerializeField] private GameObject _menuBuy;
    [SerializeField] private GameObject _menuGame;
    private bool _haveOpen;

    void Start()
    {
        _menuBuy.SetActive(false);
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
        if (_haveOpen == false) 
        { 
            _haveOpen = true;
            _menuBuy.SetActive(true);
            cameraPlayer.StopInterect();
            ResetColor();
            return;
        }
        ResetColor();
        _menuBuy.SetActive(false);
        _haveOpen = false;
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
