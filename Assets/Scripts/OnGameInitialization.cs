using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameInitialization : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _levelMenuCanvas;

    private void OnAwake()
    {
        _mainMenuCanvas.SetActive(true);
        _levelMenuCanvas.SetActive(false);
    }
}
