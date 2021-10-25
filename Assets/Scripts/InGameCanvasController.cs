using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameCanvasController : MonoBehaviour
{
    private GameObject _playingPanel;
    private GameObject _pausePanel;
    private GameObject _backToGameButton;
    private GameObject _resetButton;
    private GameObject _warningTextObject;
    private Text _gamePauseText;
    private LoadLevelScene _sceneController;

    [SerializeField] private ParticleSystem _parSys1;
    [SerializeField] private ParticleSystem _parSys2;
    [SerializeField] private Text _levelNumberText;
    [SerializeField] private Text _scoreText;

    private void Start()
    {
        InitiatePanels();
        FetchSceneController();
    }

    /// <summary>
    /// Function to fetch child components on canvas to control them
    /// </summary>
    private void InitiatePanels()
    {
        _playingPanel = transform.GetChild(0).gameObject;
        _warningTextObject = _playingPanel.transform.GetChild(1).gameObject;
        _pausePanel = transform.GetChild(1).gameObject;
        _backToGameButton = _pausePanel.transform.GetChild(2).gameObject;
        _resetButton = _pausePanel.transform.GetChild(3).gameObject;
        _gamePauseText = _pausePanel.transform.GetChild(0).gameObject.GetComponent<Text>();
        _scoreText.text = $"Current score: {CurrentScore.TotalScore}";
    }

    public void CanvasIncrementScore()
    {
        CurrentScore.IncreamentLevelScore();
        _scoreText.text = $"Current score: {CurrentScore.TotalScore + CurrentScore.LevelScore}";
    }

    public void FetchSceneController()
    {
        _sceneController = this.GetComponent<LoadLevelScene>();
    }

    public void PauseStateButton()
    {
        _levelNumberText.text = $"Level: {_sceneController.GetCurrentLevelNumber()}";
        _gamePauseText.text = "Game Paused";
        _pausePanel.SetActive(!_pausePanel.activeSelf);
        _playingPanel.SetActive(!_playingPanel.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void GameOverState()
    {
        _levelNumberText.text = $"Level: {_sceneController.GetCurrentLevelNumber()}";
        _gamePauseText.text = "Game Over";
        _pausePanel.SetActive(!_pausePanel.activeSelf);
        _playingPanel.SetActive(!_playingPanel.activeSelf);
        _backToGameButton.SetActive(!_backToGameButton.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public void GameWinState()
    {
        _levelNumberText.text = $"Level: {_sceneController.GetCurrentLevelNumber()}";
        _gamePauseText.text = "Congratulations!!";
        _pausePanel.SetActive(!_pausePanel.activeSelf);
        _playingPanel.SetActive(!_playingPanel.activeSelf);
        _backToGameButton.SetActive(!_backToGameButton.activeSelf);
        _resetButton.SetActive(!_resetButton.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;

        _parSys1.gameObject.SetActive(true);
        _parSys2.gameObject.SetActive(true);
        Debug.Log("Confetti activated");
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(0);
        CurrentScore.TotalScoreReset();
        CurrentScore.LevelScoreReset();
    }

    public void ReloadCurrentLevel()
    {
        _sceneController.ReloadCurrentLevel();
        CurrentScore.LevelScoreReset();
        Time.timeScale = 1;
    }

    public void PrintInGameWarningText(string warningTextString)
    {
        _warningTextObject.SetActive(true);

        Text warningText = _warningTextObject.GetComponent<Text>();

        warningText.text = warningTextString;
    }

    public void RemoveInGameWarningText()
    {
        _warningTextObject.SetActive(false);

        Text warningText = _warningTextObject.GetComponent<Text>();

        warningText.text = "";
    }
}
