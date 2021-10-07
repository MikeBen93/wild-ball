using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorRotationController : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _anim.SetBool("doorClosed", false);
    }

    public IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(2);

        _anim.SetBool("doorClosed", true);
    }

    public bool IsDoorClosed()
    {
        return _anim.GetBool("doorClosed");
    }
}
