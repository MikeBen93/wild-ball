using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZoneController : MonoBehaviour
{
    private LoadLevelScene _sceneController;

    private void Start()
    {
        _sceneController = GameObject.Find("InGameCanvas").GetComponent<LoadLevelScene>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.5f);

        _sceneController.LoadNextLevel();
    }
}
