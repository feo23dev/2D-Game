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
        IEntityController _entity;
        IEntityController _player;
        IMover _mover;
        IFlip _flip;
        IAnimations _anim;


        public ChasePlayer(IEntityController enemyController, IEntityController player,IMover mover,IFlip flip,IAnimations anim  )
        {
            _entity = enemyController;
            _player = player;
            _mover = mover;
            _flip = flip;
            _anim = anim;
            
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
            Vector2 leftOrRight = _player.transform.position - _entity.transform.position;

            if( leftOrRight.x > 0)
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


