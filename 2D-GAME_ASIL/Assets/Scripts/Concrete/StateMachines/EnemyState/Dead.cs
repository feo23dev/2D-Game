using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Controllers;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class Dead : IState
    {
        IEntityController _entity;

        float _currentTime = 0;
        IAnimations _animations;

        public Dead(IAnimations animations,IEntityController entity)
        {
            _entity = entity;
            _animations = animations;
        }

        public void OnEnter()
        {
            _animations.DeadAnimation();
        }

        public void OnExit()
        {
            _currentTime = 0f;
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;
            if(_currentTime > 5f)
            {
                Object.Destroy(_entity.transform.gameObject);
            }


            
        }
    }



}


