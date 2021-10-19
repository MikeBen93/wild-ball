using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticlesFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTr;

    private void Update() => transform.position = _playerTr.position;
}
