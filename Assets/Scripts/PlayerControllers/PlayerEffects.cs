using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathParticleSys;
    [SerializeField] private ParticleSystem _moveParticleSys;

    public void DeathStart()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
        _moveParticleSys.gameObject.SetActive(false);
        _deathParticleSys.gameObject.SetActive(true);
    }
}
