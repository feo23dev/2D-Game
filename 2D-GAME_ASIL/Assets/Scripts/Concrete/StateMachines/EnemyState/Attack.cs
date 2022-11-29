using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Combat;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Abstract.StateMachines;
using UProje.Combats;

namespace UProje.StateMachines.EnemyStates
{
    
    public class Attack : IState
    {
        IAnimations _animation;
        IAttacker _attacker;
        IHealth _playerHealth;
        
        IFlip _flip;
        System.Func<bool> _isRight;

        
        float _maxAttackTime;

        float _currentAttackTime;
        
        public Attack(IHealth playerHealth,IFlip flip  ,IAnimations animations, IAttacker attacker, float maxAttackTime,System.Func<bool> isRight)
        {
            _flip = flip;
            _isRight = isRight;
            _animation = animations;
            _attacker = attacker;
            _playerHealth = playerHealth;
            _maxAttackTime = maxAttackTime;
            
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            _currentAttackTime += Time.deltaTime;
            {
                if(_currentAttackTime > _maxAttackTime)
                {
                    //Vector2 leftOrRight = _playerController.transform.position - _enemyController.transform.position;
                    _flip.FlipTheObject(_isRight.Invoke() ? 1f : -1);
                    _animation.AttackAnimation();
                    _attacker.Attack(_playerHealth);
                    _currentAttackTime = 0f;
                }
            }
            
        }

        
    }

}


