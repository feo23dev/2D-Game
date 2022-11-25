using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
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
        IMover _mover;
        IAnimations _animations;
        IFlip _flip;
        IOnGround _onGround;
        StateMachine _stateMachine;
        IEntityController _player;



        private void Awake()
        {
            _mover = new MoverWithTranslate(this, moveSpeed);
            _animations = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithSRenderer(this);
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();
            

        }

        private void Start()
        {
            Idle idle = new Idle();
            Walk walk = new Walk();
            ChasePlayer chasePlayer = new ChasePlayer();
            Attack attack = new Attack();
            TakeHit takeHit = new TakeHit();
            Dead dead = new Dead();

            _stateMachine.AddTransition(idle,walk,() => isWalk);
            _stateMachine.AddTransition(idle,chasePlayer, () =>  DistancePlayerEnemy()< chaseDistance );
            _stateMachine.AddTransition(walk,chasePlayer, () => DistancePlayerEnemy() < chaseDistance );
            _stateMachine.AddTransition(chasePlayer,attack, () => DistancePlayerEnemy() < attackDistance);

            _stateMachine.AddTransition(walk,idle, ()=> !isWalk);
            _stateMachine.AddTransition(chasePlayer,idle, () => DistancePlayerEnemy()> chaseDistance);
            _stateMachine.AddTransition(attack,chasePlayer, ()=> DistancePlayerEnemy()>attackDistance);

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
            return  Vector2.Distance(transform.position, _player.transform.position);
        }
           
        












    }



}


