using UnityEngine;

public class MainMenuButton : MonoBehaviour, IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;

    [SerializeField] private int _buttonIndex = 0;

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
        MainMenuManager mainMenu = MainMenuManager.Instance;
        CameraPlayer cameraPlayer = FindAnyObjectByType<CameraPlayer>();

        switch (_buttonIndex)
        {
            case 0:
                mainMenu.StartGame();
                break;
            case 1:
                mainMenu.HowToPlay();
                break;
            case 2:
                mainMenu.QuitGame();
                break;
        }

        ResetColor();
        cameraPlayer?.StopInterect();
    }

    public void PossibleToInterect()
    {
        if (_materialInstance != null)
        {
            Color baseColor = _materialInstance.GetColor("_BaseColor");
            Color bluish = new Color(baseColor.r * 0.8f, baseColor.g * 0.8f, 1f, baseColor.a);
            _materialInstance.SetColor("_BaseColor", bluish);
        }
    }

    public void ResetColor()
    {
        _materialInstance?.SetColor("_BaseColor", _originalColor);
    }
}
