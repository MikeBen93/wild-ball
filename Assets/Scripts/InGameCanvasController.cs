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
    private GameObject _warningTextObject;
    private Text _gamePauseText;
    private LoadLevelScene _sceneController;

    [SerializeField] private Text _levelNumberText;

    private void Start()
    {
        InitiatePanels();
        FetchSceneController();
    }

    private void InitiatePanels()
    {
        _playingPanel = transform.GetChild(0).gameObject;
        _warningTextObject = _playingPanel.transform.GetChild(1).gameObject;
        _pausePanel = transform.GetChild(1).gameObject;
        _backToGameButton = _pausePanel.transform.GetChild(2).gameObject;
        _gamePauseText = _pausePanel.transform.GetChild(0).gameObject.GetComponent<Text>();
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
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void GameOverState()
    {
        _levelNumberText.text = $"Level: {_sceneController.GetCurrentLevelNumber()}";
        _gamePauseText.text = "Game Over";
        _pausePanel.SetActive(!_pausePanel.activeSelf);
        _backToGameButton.SetActive(!_backToGameButton.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadCurrentLevel()
    {
        _sceneController.ReloadCurrentLevel();
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