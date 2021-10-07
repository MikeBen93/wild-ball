using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private Transform _teleportExitZone;
    [SerializeField] private InGameCanvasController _canvasController;

    private bool _playerInsideZone;
    private GameObject _playerObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _canvasController.PrintInGameWarningText("Press E to teleport");
            _playerInsideZone = true;
            _playerObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasController.RemoveInGameWarningText();
            _playerInsideZone = false;
        }
    }

    private void Update()
    {
        if (_playerInsideZone && Input.GetKeyDown(KeyCode.E))
        {
            _playerObject.transform.position = new Vector3(_teleportExitZone.position.x, _playerObject.transform.position.y, _teleportExitZone.position.z);
        }
    }
}
