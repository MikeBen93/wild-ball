using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScore : MonoBehaviour
{
    public static int Score
    { get; private set; }

    public static void ResetScore() => Score = 0;
    public static void IncreamentScore() => Score++;
}
