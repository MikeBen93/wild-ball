using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScore : MonoBehaviour
{
    public static int TotalScore
    { get; private set; }
    public static int LevelScore
    { get; private set; }

    public static void TotalScoreReset() => TotalScore = 0;
    public static void LevelScoreReset() => LevelScore = 0;
    public static void IncreamentLevelScore() => LevelScore++;
    public static void IncreamentTotalScore()
    {
        TotalScore += LevelScore;
        LevelScore = 0;
    }
}
