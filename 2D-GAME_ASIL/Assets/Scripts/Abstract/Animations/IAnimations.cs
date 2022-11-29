using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UProje.Abstract.Animations
{
    public interface IAnimations 
    {
        
        public void MoveAnimatiton(float HorizontalForce);

        public void JumpAnimation(bool isJump);
        public void AttackAnimation();
        void TakeHitAnimation();
        void DeadAnimation();

       
    }

}


