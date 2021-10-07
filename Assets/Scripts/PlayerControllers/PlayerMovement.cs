using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{ 
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 50)] private int _speed = 10;
        private Rigidbody _playerRigidbody;

        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            _playerRigidbody.AddForce(movement * _speed);
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            _speed = 10;
        }
#endif
    }
}

