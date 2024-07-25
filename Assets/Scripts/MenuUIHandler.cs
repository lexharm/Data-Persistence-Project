using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private GameManager _gameManager => GameManager.Instance;

    private void Start()
    {
        if (_gameManager != null)
        {
            _bestScoreText.SetText($"Best Score: {_gameManager.BestPlayerName}: {_gameManager.BestScore}");
        }
    }

    public void StartGame()
    {
        _gameManager.PlayerName = _nameInput.text;
        _gameManager.StartGame();
    }

    public void Quit()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
