using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Animations;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Movements;

namespace UProje.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        IMover _mover;
        IAnimations _animations;
        IFlip _flip;
        IOnGround _onGround;
        [SerializeField] float moveSpeed =2f;

        private void Awake()
        {
            _mover = new MoverWithTranslate(this,moveSpeed);
            _animations = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithSRenderer(this);
            _onGround = GetComponent<IOnGround>();

        }












    }



}


