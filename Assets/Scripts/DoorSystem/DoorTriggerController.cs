using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    [SerializeField] private DoorRotationController _rotationController;
    [SerializeField] private InGameCanvasController _canvasController;

    private bool _playerInsideZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasController.PrintInGameWarningText("Press E to open the door");
            _playerInsideZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasController.RemoveInGameWarningText();
            _playerInsideZone = false;
            if (!_rotationController.IsDoorClosed()) StartCoroutine(_rotationController.CloseDoor());
        }
    }

    private void Update()
    {
        if (_playerInsideZone && Input.GetKeyDown(KeyCode.E))
        {
            _rotationController.OpenDoor();
        }
    }

    
}
