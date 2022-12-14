using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Combat;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Combats;
using UProje.Movements;
using UProje.StateMachines;
using UProje.StateMachines.EnemyStates;

namespace UProje.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {

        [SerializeField] float moveSpeed = 2f;
        [SerializeField] float chaseDistance = 3f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] float attackCooldown = 2f;
        [SerializeField] bool isWalk = false;
        //[SerializeField] bool isTakeHit = false;
        [SerializeField] Transform[] patrols;
        IMover _mover;
        IAnimations _animations;
        IFlip _flip;
        IOnGround _onGround;
        StateMachine _stateMachine;
        IEntityController _player;
        IHealth _health;
        IAttacker _attacker;
        IStopOnEdge _stopEdge;
        float maxAttackTime;

        



        private void Awake()
        {
            _mover = new MoverWithTranslate(this, moveSpeed);
            _animations = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithSRenderer(this);
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();
            _health = GetComponent<IHealth>();
            _attacker = GetComponent<IAttacker>();
            _stopEdge = GetComponent<IStopOnEdge>();

        }

        

        private void Start()
        {
            Idle idle = new Idle(_mover,_animations);
            Walk walk = new Walk(_flip,this,_mover,_animations,patrols);
            ChasePlayer chasePlayer = new ChasePlayer(this,_mover,_flip,_animations,_stopEdge,isRight);
            Attack attack = new Attack(_player.transform.GetComponent<IHealth>(),_flip,_animations,_attacker,maxAttackTime,isRight);
            TakeHit takeHit = new TakeHit(_health,_animations);
            Dead dead = new Dead(_animations,this);

            _stateMachine.AddTransition(idle, walk, () => !idle.IsIdle );
            _stateMachine.AddTransition(idle, chasePlayer, () => DistancePlayerEnemy() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistancePlayerEnemy() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistancePlayerEnemy() < attackDistance);

            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistancePlayerEnemy() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistancePlayerEnemy() > attackDistance);

            _stateMachine.AddAnyState(dead, () => _health.IsDead);
            _stateMachine.AddAnyState(takeHit, () => takeHit.isTakeHit);
            _stateMachine.AddTransition(takeHit,chasePlayer,() => takeHit.isTakeHit == false);

            _stateMachine.SetState(idle);

            




        }

        

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnDrawGizmos()
        {

        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        private float DistancePlayerEnemy()
        {
            return Vector2.Distance(transform.position, _player.transform.position);
        }

        private bool isRight()
        {
            Vector2 result = _player.transform.position - this.transform.position;
            if(result.x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }















    }



}


