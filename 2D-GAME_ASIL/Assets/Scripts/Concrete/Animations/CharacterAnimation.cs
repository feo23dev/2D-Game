using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Controllers;

public class CharacterAnimation :  IAnimations
{
    Animator _animator;
    
    public CharacterAnimation(Animator animator)
    {
        _animator = animator; 
    }

    public void JumpAnimation(bool isJump)
    {
        _animator.SetBool("isJump",isJump);
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("attack");
    }
    
    public void MoveAnimatiton(float Horizontal)
    {
        _animator.SetFloat("Blend",Mathf.Abs(Horizontal));
    }

    public void TakeHitAnimation()
    {
        _animator.SetTrigger("takehit");
    }

    public void DeadAnimation()
    {
        _animator.SetTrigger("death");
    }
}
