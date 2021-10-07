using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 _offset = new Vector3(0, 4.5f, -7.5f);
    private Vector3 _cameraRotation = new Vector3(27.969f, 0, 0);

    private void Start()
    {
        transform.position = _playerTransform.transform.position + _offset;
    }

    private void Update()
    {
        transform.position = _playerTransform.transform.position + _offset;
    }

#if UNITY_EDITOR
    [ContextMenu("Set camera position")]
    public void SetCameraPosition()
    {
        transform.position = _playerTransform.transform.position + _offset;
        transform.rotation = Quaternion.Euler(_cameraRotation);
    }
#endif
}
