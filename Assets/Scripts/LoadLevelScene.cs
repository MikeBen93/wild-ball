using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelScene : MonoBehaviour
{
    private Scene _currentScene;
    private int _finalLevelNumber = 5;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    public int GetCurrentLevelNumber()
    {
        return _currentScene.buildIndex;
    }

    public void LoadLevelSceneOnClick()
    {
        int levelIndex = Convert.ToInt32(GetComponentInChildren<Text>().text);
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        int levelIndex = GetCurrentLevelNumber();
        if(levelIndex!= _finalLevelNumber) SceneManager.LoadScene(++levelIndex);
        else SceneManager.LoadScene(0);
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(_currentScene.name);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
