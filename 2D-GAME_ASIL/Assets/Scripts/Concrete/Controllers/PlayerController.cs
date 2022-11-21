using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Inputs;
using UProje.Abstract.Movements;
using UProje.Inputs;
using UProje.Movements;

namespace UProje.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IPlayerInput _IPlayerInput;
        IAnimations _animation;
        IMover _mover; // give the interface IMover
        float _horizontal;
        IFlip _flip;

        private void Awake()
        {
            _IPlayerInput = new PCInput();
            _mover = new MoverWithTranslate(this); // can't instantiate interface( abstract class)
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithSRenderer(this);
            
        }

        private void Update()
        {   
            _horizontal = _IPlayerInput.Horizontal; 
            _flip.FlipTheObject(_horizontal);
        }

        private void FixedUpdate()
        {
            _mover.Tick(_horizontal);
            _animation.MoveAnimatiton(_horizontal);
            
            
        }
    }


}


