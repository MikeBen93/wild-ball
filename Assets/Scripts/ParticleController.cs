using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem _particle;
    private bool _gamePaused;
    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _gamePaused = true;
        Debug.Log("Confetti awaked");
    }

    void Update()
    {
        if (_gamePaused)
        {
            Debug.Log("Confetti simulation activated " + Time.unscaledDeltaTime);
            _particle.Simulate(Time.unscaledDeltaTime, true, false);
        }
    }
}
