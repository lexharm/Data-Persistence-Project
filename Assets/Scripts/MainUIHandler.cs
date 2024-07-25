using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;

    private GameManager _gameManager => GameManager.Instance;

    void Start()
    {
        if (_gameManager != null)
        {
            UpdateBestScoreText();
        }
    }

    public void UpdateBestScoreText()
    {
        _bestScoreText.text = $"Best Score: {_gameManager.BestPlayerName}: {_gameManager.BestScore}";
    }
}
