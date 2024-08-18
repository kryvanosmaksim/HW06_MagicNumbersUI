using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    [Header("Number Settings")]
    [SerializeField] private int _max = 1000;
    [SerializeField] private int _min;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _displayText;
    [SerializeField] private Button _buttonLower;
    [SerializeField] private Button _buttonHigher;
    [SerializeField] private Button _buttonCorrect;

    private int _guess;
    private int _guessCount;
    private int _startMax;
    private int _startMin;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _displayText.text = "";
        _startMax = _max;
        _startMin = _min;
        _buttonLower.onClick.AddListener(OnLowerButtonPressed);
        _buttonHigher.onClick.AddListener(OnHigherButtonPressed);
        _buttonCorrect.onClick.AddListener(OnCorrectButtonPressed);
        RestartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnLowerButtonPressed();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnHigherButtonPressed();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCorrectButtonPressed();
        }
    }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        _guess = (_max + _min) / 2;
        _guessCount++;
        _displayText.text += $"\nIs your number {_guess}?";
    }

    private void OnCorrectButtonPressed()
    {
        GameData.GuessedNumber = _guess;
        GameData.GuessCount = _guessCount;

        SceneManager.LoadScene("WinScene");
    }

    private void OnHigherButtonPressed()
    {
        _min = _guess;
        CalculateGuessAndLog();
    }

    private void OnLowerButtonPressed()
    {
        _max = _guess;
        CalculateGuessAndLog();
    }

    private void RestartGame()
    {
        _max = _startMax;
        _min = _startMin;
        _guessCount = 0;
        _displayText.text += $"Think of a number between {_min} and {_max}";

        CalculateGuessAndLog();
    }

    #endregion
}