using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Controllers;
using UProje.Abstract.Inputs;
using UProje.Abstract.Movements;
using UProje.Inputs;
using UProje.Movements;

namespace UProje.Controllers
{
    public class PlayerController : MonoBehaviour ,IEntityController
    {
        IPlayerInput _IPlayerInput;
        IAnimations _animation;
        IMover _mover; // give the interface IMover
        float _horizontal;
        float _vertical;
        IFlip _flip;
        IJump _jump;
        IOnGround _onGround;
        [SerializeField] float _moveSpeed=3f;
        
        
        

        private void Awake()
        {
            _IPlayerInput = new PCInput();
            _mover = new MoverWithTranslate(this,_moveSpeed); // can't instantiate interface( abstract class)
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithSRenderer(this);
            _onGround = GetComponent<OnGround>();
            _jump = new JumpMulti(GetComponent<Rigidbody2D>(),_onGround);
            

        }

        private void Update()
        {   
            if(_IPlayerInput.attack)
            {
                _animation.AttackAnimation();
                return;
            }
            _horizontal = _IPlayerInput.Horizontal; 
            


            if(_IPlayerInput.jump)
            {
                _jump.isJump = true;
            }
            _animation.JumpAnimation(_jump.isJump); 
            
        }

        private void FixedUpdate()
        {
            

            _flip.FlipTheObject(_horizontal);
            _jump.Jumper();
            
            _mover.Tick(_horizontal);
            _animation.MoveAnimatiton(_horizontal); 
        }
    }


}


