using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class ChasePlayer : IState
    {
        
        IMover _mover;
        IFlip _flip;
        IAnimations _anim;
        System.Func<bool> _isRight;


        public ChasePlayer(IMover mover,IFlip flip,IAnimations anim,System.Func<bool> isRight)
        {
            _mover = mover;
            _flip = flip;
            _anim = anim;
            _isRight = isRight;
            
        }
        public void OnEnter()
        {
            _anim.MoveAnimatiton(1F);
           
        }

        public void OnExit()

        {
            _anim.MoveAnimatiton(0f);    
        }

        public void Tick()
        {
            

            if( _isRight.Invoke())
            {
                _mover.Tick(1.4f);
                _flip.FlipTheObject(1f);
            }
            else
            {
                _mover.Tick(-1.4f);
                _flip.FlipTheObject(-1f);
            }
        }
    }



}


