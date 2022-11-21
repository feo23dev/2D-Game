using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Controllers;

namespace UProje.Movements
{
    public class Jump : IJump
    {
        
        float _jumpForce = 250f;
        IOnGround _onGround;
        Rigidbody2D _rigidbody;
        

        public Jump(Rigidbody2D rigidbody, IOnGround onGround)
        {
            _rigidbody = rigidbody;
            _onGround = onGround;

        }

        public bool isJump { get; set ; }

        public void Jumper()
        {
            if(isJump && _onGround.onGround)
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.AddForce(Vector2.up * _jumpForce);
                _rigidbody.velocity = Vector2.zero;
                isJump = false;
            }
        }
    }

}

