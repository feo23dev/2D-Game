using System;
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
        IStopOnEdge _stopEdge;
        IEntityController _entity;



        public ChasePlayer(IEntityController entity, IMover mover, IFlip flip, IAnimations anim, IStopOnEdge stopEdge, System.Func<bool> isRight)
        {
            _entity = entity;
            _mover = mover;
            _flip = flip;
            _anim = anim;
            _isRight = isRight;
            _stopEdge = stopEdge;

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
            

            if (_stopEdge.HasReachEdge())
            {
                if(_stopEdge.isRightDirection && !_isRight.Invoke())
                {
                    ChaseAgain(1f,-1f,-1f);
                    return;

                }
                if(!_stopEdge.isRightDirection && _isRight.Invoke())
                {
                    ChaseAgain(1f,1f,1f);
                    return;
                }
                _anim.MoveAnimatiton(0f);
                
                return;
            }

            if (_isRight.Invoke())
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

        private void ChaseAgain(float speedForAnimation, float flipDireciton, float speedForTick)
        {
            _anim.MoveAnimatiton(speedForAnimation);  
            _flip.FlipTheObject(flipDireciton);
            _mover.Tick(speedForTick);
            
        }
    }



}


