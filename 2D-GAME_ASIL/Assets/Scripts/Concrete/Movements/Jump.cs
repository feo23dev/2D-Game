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
        
        float jumpForce = 250f;
        Rigidbody2D _rigidbody;
        

        public Jump(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Jumper()
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * jumpForce);
            _rigidbody.velocity = Vector2.zero;
        }
    }

}

