using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Combat;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
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
        [SerializeField] bool isWalk = false;
        [SerializeField] bool isTakeHit = false;
        [SerializeField] Transform[] patrols;
        IMover _mover;
        IAnimations _animations;
        IFlip _flip;
        IOnGround _onGround;
        StateMachine _stateMachine;
        IEntityController _player;
        IHealth _health;



        private void Awake()
        {
            _mover = new MoverWithTranslate(this, moveSpeed);
            _animations = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithSRenderer(this);
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();
            _health = GetComponent<IHealth>();


        }

        private void OnEnable()
        {
            _health.OnHealthChange += HandleHealthChange;
        }

        private void Start()
        {
            Idle idle = new Idle(_mover,_animations);
            Walk walk = new Walk(this,_mover,_animations,_flip,patrols);
            ChasePlayer chasePlayer = new ChasePlayer();
            Attack attack = new Attack();
            TakeHit takeHit = new TakeHit();
            Dead dead = new Dead();

            _stateMachine.AddTransition(idle, walk, () => !idle.IsIdle );
            _stateMachine.AddTransition(idle, chasePlayer, () => DistancePlayerEnemy() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistancePlayerEnemy() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistancePlayerEnemy() < attackDistance);

            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistancePlayerEnemy() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistancePlayerEnemy() > attackDistance);

            _stateMachine.AddAnyState(dead, () => _health.CurrentHealth < 1);
            _stateMachine.AddAnyState(takeHit, () => isTakeHit);
            _stateMachine.AddTransition(takeHit,chasePlayer,() => isTakeHit == false);

            _stateMachine.SetState(idle);




        }

        private void HandleHealthChange()
        {
            isTakeHit = true;
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















    }



}


