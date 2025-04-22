using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView 
{
    private Animator _animator;
    private CapsuleCollider _standingCollider, _crouchingCollider;
    public PlayerView(Animator anim, CapsuleCollider standingcollider, CapsuleCollider crouchCollider)
    {
        _animator = anim;
        _standingCollider = standingcollider;
        _crouchingCollider = crouchCollider;
    }

    public void MovementPressed()
    {
        _animator.SetBool("isRunning", true);
    }

    public void MovementStatic()
    {
        _animator.SetBool("isRunning", false);
    }

    public void JumpPressed()
    {
        _animator.SetBool("isJumping", true);
    }

    public void JumpEnd()
    {
        _animator.SetBool("isJumping", false);
    }

    public void DuckStart()
    {
        _animator.SetBool("isDucking", true);
        _crouchingCollider.enabled = true;
        _standingCollider.enabled = false;
    }

    public void DuckEnd()
    {
        _animator.SetBool("isDucking", false);
        _crouchingCollider.enabled = false;
        _standingCollider.enabled = true;
    }
}
