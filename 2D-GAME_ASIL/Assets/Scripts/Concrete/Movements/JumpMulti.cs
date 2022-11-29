using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Movements;

namespace UProje.Movements
{
    public class JumpMulti : IJump
    {
        float _jumpForce = 250f;
        Rigidbody2D _rigidbody;
        int _maxJumpCount = 2;
        int _currentJumpCount = 0;
        IOnGround _onGround;

        public bool isJump { get; set; }

        public JumpMulti(Rigidbody2D rigidbody, IOnGround onGround)
        {
            _rigidbody = rigidbody;
            _onGround = onGround;
        }

        private void Update()
        {
            
        }
        public void Jumper()
        {
            if (isJump)
            {
                
                if (_currentJumpCount < _maxJumpCount)
                {
                    _rigidbody.velocity = Vector2.zero;
                    _rigidbody.AddForce(Vector2.up * _jumpForce);
                    _rigidbody.velocity = Vector2.zero;

                    _currentJumpCount++;
                    
                }
                if (_onGround.onGround)
                {
                    isJump = false;
                    _currentJumpCount = 0;
                }
            }





        }


    }


}

