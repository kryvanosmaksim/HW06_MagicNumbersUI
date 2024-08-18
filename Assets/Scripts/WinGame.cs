using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class WinGame : MonoBehaviour
{
    #region Variables

    [Header("UI")]
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _headerLabel;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _playAgainButton.onClick.AddListener(EnterGame);
        _exitButton.onClick.AddListener(ExitGame);

        int guessedNumber = GameData.GuessedNumber;
        int guessCount = GameData.GuessCount;
        _headerLabel.text = $"Hooray! Your number is {guessedNumber}\nNumber of attempts: {guessCount}";
    }

    #endregion

    #region Public methods

    public void EnterGame()
    {
        Debug.Log("Enter Game");
        SceneManager.LoadScene("StartScene");
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