using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _textHowToPlay;
    [SerializeField] private string _textPlay;

    public UnityEvent OnStartGame;
    public UnityEvent OnHowToPlay;
    public UnityEvent OnQuitGame;

    private bool _howOpen = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        OnStartGame.AddListener(LoadScene);
        OnHowToPlay.AddListener(ShowHowToPlay);
        OnQuitGame.AddListener(LeaveGame);
    }

    public void StartGame() => OnStartGame?.Invoke();
    public void HowToPlay() => OnHowToPlay?.Invoke();
    public void QuitGame() => OnQuitGame?.Invoke();

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    private void ShowHowToPlay()
    {
        if (_textHowToPlay != null)
        {
            if (_howOpen == false )
            {
                _textHowToPlay.text = _textPlay;
                _howOpen = true;
                return;
            }
            _textHowToPlay.text = "";
            _howOpen = false;
        }
            
    }

    private void LeaveGame()
    {
        Application.Quit();
    }
}
