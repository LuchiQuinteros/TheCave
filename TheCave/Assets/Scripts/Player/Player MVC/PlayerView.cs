using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView 
{
    private Animator _animator;
    public PlayerView(Animator anim)
    {
        _animator = anim;
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
}
