using TMPro;
using UnityEngine;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _max = 1000;
    [SerializeField] private int _min;
    [SerializeField] private TextMeshProUGUI _displayText;

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
        RestartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _max = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _min = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _displayText.text += $"\nУра! Твое число угадано и равно {_guess}!";
            _displayText.text += $"\nКоличество затраченных ходов: {_guessCount}";
            _displayText.text += "\n";

            RestartGame();
        }
    }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        _guess = (_max + _min) / 2;
        _guessCount++;
        _displayText.text += $"\nТвое число равно {_guess}?";
    }

    private void RestartGame()
    {
        _max = _startMax;
        _min = _startMin;
        _guessCount = 0;
        _displayText.text += $"Загадай число от {_min} до {_max}";

        CalculateGuessAndLog();
    }

    #endregion
}