using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Movements;
using UProje.Controllers;

namespace UProje.Movements
{
    public class MoverWithVelocity : IMover
    {
        Rigidbody2D _rb;
        float moveSpeed = 80f;
        public MoverWithVelocity(PlayerController playerController)
        {
            _rb = playerController.GetComponent<Rigidbody2D>();
            
        }
        public void Tick(float Horizontal)
        {
            Vector2 direction = Vector2.right * Horizontal;
            _rb.velocity= direction.normalized*Time.fixedDeltaTime * moveSpeed;
        }
    }


}

