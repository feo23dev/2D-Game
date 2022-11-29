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
        IEntityController _entityController;
        IFlip _flip;
        float _direction;
        int _patrolIndex = 0;
        Transform[] _patrols;
        Transform _currentPatrol;

        public bool IsWalking { get; private set; }

        public Walk(IFlip flip, IEntityController entityController, IMover mover, IAnimations animations, params Transform[] patrols)
        {
            _flip = flip;
            _mover = mover;
            _animations = animations;
            _patrols = patrols;
            _entityController = entityController;


        }
        public void OnEnter()
        {
            if (_patrols.Length < 1) return;

            _currentPatrol = _patrols[_patrolIndex];
            Vector2 leftOrRight = _currentPatrol.position - _entityController.transform.position;
            _flip.FlipTheObject(leftOrRight.x > 0f ? 1f : -1f);

            _direction = _entityController.transform.localScale.x;
            _animations.MoveAnimatiton(1f);
            IsWalking = true;
        }

        public void OnExit()
        {

            _animations.MoveAnimatiton(0f);

            
            _patrolIndex++;

            if (_patrolIndex >= _patrols.Length)
            {
                _patrolIndex = 0;
            }



        }

        public void Tick()
        {
            if (_currentPatrol == null) return;

            if (Vector2.Distance(_entityController.transform.position, _currentPatrol.position) <= 0.2f)
            {
                IsWalking = false;
                return;

            }
            _mover.Tick(_direction);
        }
    }


}


