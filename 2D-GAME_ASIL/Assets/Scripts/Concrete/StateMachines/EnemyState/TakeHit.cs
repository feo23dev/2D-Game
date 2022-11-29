using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Combat;
using UProje.Abstract.StateMachines;
using UProje.Abstract.Animations;

namespace UProje.StateMachines.EnemyStates
{
    public class TakeHit : IState
    {
        IAnimations _anim;
        IHealth _health;
        float _maxDelayTime=5f;
        float _currentDelayTime = 0;

        public bool isTakeHit {  get; private set; }
        public TakeHit(IHealth health,IAnimations animation)
        {
            _health = health;
            _anim = animation;
            health.OnHealthChange += OnEnter;
            
        }
        
        public void OnEnter()
        {
            isTakeHit = true;
            _anim.TakeHitAnimation();
        }

        public void OnExit()
        {
            _currentDelayTime = 0;
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;
            if(_currentDelayTime > _maxDelayTime && isTakeHit)
            {
                isTakeHit = false; // vurduktan sonra kaç saniye beklesin! stun mechanic !
            }
        }
    }



}


