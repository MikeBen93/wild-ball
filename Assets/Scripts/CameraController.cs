using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 _offset = new Vector3(0.0f, 9.9f, -3.0f);
    private Vector3 _cameraRotation = new Vector3(75f, 0, 0);

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

    [ContextMenu("Get camera position")]
    public void GetCameraPosition()
    {
        _offset = transform.position - _playerTransform.transform.position;
        _cameraRotation = transform.rotation.eulerAngles;
        Debug.Log($"_offset = {_offset}");
        Debug.Log($"_cameraRotation = {_cameraRotation}");
    }
#endif
}
