using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Movements;
using UProje.Controllers;

namespace UProje.Movements
{
    public class FlipWithSRenderer :  IFlip
    {
        SpriteRenderer _spriteRenderer;
        public FlipWithSRenderer(PlayerController player)
        {
            _spriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
            
        }

            public void FlipTheObject(float direction)
        {
            if( direction > 0)
            {
                _spriteRenderer.flipX = false;
            }
            if(direction < 0)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }

   


}


