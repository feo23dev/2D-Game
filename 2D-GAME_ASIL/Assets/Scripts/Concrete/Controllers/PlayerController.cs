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
        public bool _isjump=false;
        

        private void Awake()
        {
            _IPlayerInput = new PCInput();
            _mover = new MoverWithTranslate(this); // can't instantiate interface( abstract class)
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithSRenderer(this);
            _jump = new Jump(GetComponent<Rigidbody2D>());
            _onGround = GetComponent<OnGround>();

        }

        private void Update()
        {   
            _horizontal = _IPlayerInput.Horizontal; 
            _flip.FlipTheObject(_horizontal);
            if(_IPlayerInput.jump && _onGround.onGround)
            {
                _isjump = true;
            }
            
        }

        private void FixedUpdate()
        {
            if(_isjump)
            {
                _jump.Jumper();
                _isjump = false;
            }
            _mover.Tick(_horizontal);
            _animation.MoveAnimatiton(_horizontal);
            
            
            
        }
    }


}


