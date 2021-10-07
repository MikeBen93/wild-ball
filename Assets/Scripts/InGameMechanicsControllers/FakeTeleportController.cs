using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTeleportController : MonoBehaviour
{
    [SerializeField] private InGameCanvasController _canvasController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasController.PrintInGameWarningText("It's a fake teleport, seek another teleport");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasController.RemoveInGameWarningText();
        }
    }
}
