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
    
    public void MoveAnimatiton(float Horizontal)
    {
        _animator.SetFloat("Blend",Mathf.Abs(Horizontal));
    }


}
