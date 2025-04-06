using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    
    void AttackEnd()
    {
        _animator.SetBool("isAttacking", false);
    }
}
