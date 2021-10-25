using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInitialization : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("MainMenu Awake");
        CurrentScore.TotalScoreReset();
        CurrentScore.LevelScoreReset();
    }
}
