using UnityEngine;

public class CombatButton : MonoBehaviour, IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;

    [SerializeField] private GameObject _menuTurn;
    [SerializeField] private GameObject _camPlayer;
    [SerializeField] private GameObject _camCombat;

    private bool _haveOpen;
    private bool _turnCombatON;

    public bool TurnCombatON { get => _turnCombatON; set => _turnCombatON = value; }
    public bool HaveOpen { get => _haveOpen; set => _haveOpen = value; }

    void Start()
    {
        _menuTurn.SetActive(false);
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
        if (HaveOpen == false)
        {
            HaveOpen = true;
            _menuTurn.SetActive(true);
            cameraPlayer.StopInterect();
            ResetColor();
            return;
        }

        if (TurnCombatON)
        {
            _camPlayer.SetActive(true);
            _camCombat.SetActive(false);
            cameraPlayer.StopInterect();
            ResetColor();
        }

        ResetColor();
        _menuTurn.SetActive(false);
        HaveOpen = false;
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
