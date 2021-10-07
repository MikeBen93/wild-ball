using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    [SerializeField] private HingeJoint _catapultHinge;
    [SerializeField] private InGameCanvasController _canvasController;

    private bool _playerInsideZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvasController.PrintInGameWarningText("Press E to fire catapult");
            _playerInsideZone = true;
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

    void Update()
    {
        if (_playerInsideZone && Input.GetKeyDown(KeyCode.E))
        {
            FireCatapult();
            StartCoroutine(SetCatapultBack());
        }
    }

    private void FireCatapult()
    {
        JointSpring hingeSpring = _catapultHinge.spring;
        hingeSpring.targetPosition = 45;
        _catapultHinge.spring = hingeSpring;
    }

    private void ResetCatapult()
    {
        JointSpring hingeSpring = _catapultHinge.spring;
        hingeSpring.targetPosition = 0;
        _catapultHinge.spring = hingeSpring;
    }

    private IEnumerator SetCatapultBack()
    {
        yield return new WaitForSeconds(2);

        ResetCatapult();
    }
}
