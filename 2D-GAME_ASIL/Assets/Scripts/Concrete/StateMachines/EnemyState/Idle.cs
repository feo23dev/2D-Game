using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class Idle : IState
    {
        IMover _mover;
        IAnimations _animations;
        IFlip _flip;
        IEntityController _entity;
        float _direction;

        
        float _maxStandTime;
        float _currentStandTime = 0f;

        public bool IsIdle { get; private set; }
        public Idle(IMover mover,IAnimations animation)
        {
            
            _mover = mover;
            _animations = animation;
            
        }
        public void OnEnter()
        {
            
            IsIdle = true;
            _animations.MoveAnimatiton(0);

            _maxStandTime = Random.Range(3f,10f);
            
            
            
        }

        public void OnExit()
        {
            _currentStandTime = 0f;
            
            
        }

        public void Tick()
        {
            _mover.Tick(0f);  
            _currentStandTime += Time.deltaTime;
            if(_currentStandTime > _maxStandTime)
            {
                IsIdle = false;
            }
            Debug.Log("Idle on Tick");
            
        }
    }



}


