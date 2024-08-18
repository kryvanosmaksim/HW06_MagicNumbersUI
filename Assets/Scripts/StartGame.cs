using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartGame : MonoBehaviour
{
    #region Variables

    [Header("UI")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Debug.Log("StartGame Start");
        _startButton.onClick.AddListener(EnterGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    public void Update()
    {
        Debug.Log("StartGame Update");
    }

    private void OnDestroy()
    {
        Debug.LogWarning("StartGame OnDestroy");
    }

    #endregion

    #region Public methods

    public void EnterGame()
    {
        Debug.Log("Enter Game");
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    #endregion
}