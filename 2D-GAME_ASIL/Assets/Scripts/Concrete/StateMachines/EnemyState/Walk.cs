using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class Walk : IState
    {
        IMover _mover;
        IAnimations _animations;
        IFlip _flip;
        IEntityController _entityController;
        float _direction =1f;
        int _patrolIndex = 0;
        Transform[] _patrols;
        Transform _currentPatrol;

        public bool IsWalking { get; private set; }

        public Walk(IEntityController entityController ,IMover mover,IAnimations animations, IFlip flip,params Transform[] patrols )
        {
            _mover = mover;
            _animations = animations;
            _flip = flip;
            _patrols = patrols;
            _entityController = entityController;
            
            
        }
        public void OnEnter()
        {
            _currentPatrol =  _patrols[_patrolIndex];
            _animations.MoveAnimatiton(_direction);
            IsWalking = true;
            
        }

        public void OnExit()
        {
            _direction *= -1;
            _flip.FlipTheObject(_direction);
            _animations.MoveAnimatiton(0f);
            _patrolIndex++;
            if (_patrolIndex >= _patrols.Length)
            {
                _patrolIndex = 0 ;
            }
            _currentPatrol = _patrols[_patrolIndex];
            
            
        }

        public void Tick()
        {
            if(Vector2.Distance(_entityController.transform.position,_currentPatrol.position)<= 0.2f)
            {
                IsWalking = false;
                return; // dont do moverTick
            }
            _mover.Tick(_direction);
        }
    }


}


