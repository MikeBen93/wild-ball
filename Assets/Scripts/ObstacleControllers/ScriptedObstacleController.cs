using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedObstacleController : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _moveSpeed = 0.4f;
    [SerializeField] private float _rotationSpeed = 500;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private int _rotationDirection = -1;

    private float _t;
    // Start is called before the first frame update
    private void Start()
    {
        _startPosition = _startPoint.position;
        _endPosition = _endPoint.position;

        transform.position = _startPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        _t += Time.deltaTime * _moveSpeed;

        transform.position = Vector3.Lerp(_startPosition, _endPosition, _t);

        if (_t >= 1)
        {
            var start = _startPosition;
            var end = _endPosition;

            _startPosition = end;
            _endPosition = start;

            _t = 0;
            _rotationDirection *= -1;
        }

        transform.Rotate(_rotationDirection * _rotationSpeed * Time.deltaTime * Vector3.back);
    }
}
