using UnityEngine;

public class CombatManager : MonoBehaviour, IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;

    [SerializeField] private int _actionToDo = 0;
    [SerializeField] private GameObject _camPlayer;
    [SerializeField] private GameObject _camTable;
    [SerializeField] private CombatButton _button;
    [SerializeField] private GameObject _menuTurn;

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
        if (_actionToDo == 0)
        {
            _camPlayer.SetActive(false);
            _camTable.SetActive(true);
            _button.TurnCombatON = true;
            
            _menuTurn.SetActive(false);
        }
        else if (_actionToDo == 1)
        {
            _button.HaveOpen = false;
            _menuTurn.SetActive(false);
            ResetColor();
            cameraPlayer.StopInterect();
            return;
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
