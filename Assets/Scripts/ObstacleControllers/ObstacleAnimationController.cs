using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObstacleAnimationController : MonoBehaviour
{
    private Animator _anim;
    private int _nextAnimation = 0;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimationStateController();
    }

    /// <summary>
    /// Function randomly choose which animation play next
    /// </summary>
    private void AnimationStateController()
    {
        if (
            _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= _anim.GetCurrentAnimatorStateInfo(0).length &&
            _anim.GetCurrentAnimatorStateInfo(0).IsName("ObstacleAnimationIdle")
            )
        {
            _nextAnimation = Random.Range(1, 4);
            _anim.SetInteger("NextAnimation", _nextAnimation);
        }

        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("ObstacleAnimationIdle"))
        {
            _anim.SetInteger("NextAnimation", 0);
        }
    }
}
