using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnMoveController : MonoBehaviour
{
    private ParticleSystem _particlesOnMove;
    private Rigidbody _playerRg;

    private void Awake()
    {
        _particlesOnMove = this.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>();
        _playerRg = GetComponent<Rigidbody>();
    }

    public void ParticlesEmission(Vector3 addedForceDirection)
    {
        _particlesOnMove.Play();
        var sh = _particlesOnMove.shape;
        if (addedForceDirection.magnitude == 0)
        {
            _particlesOnMove.Stop();
        }
        else
        {
            _particlesOnMove.Play();
            sh.rotation = new Vector3(280, 0, 0);
        }
        
    }
}
