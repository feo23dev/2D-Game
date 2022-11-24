using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Controllers;

namespace UProje.Movements
{
    public class FlipWithSRenderer :IFlip 
    {
        IEntityController _entity;
        
        public FlipWithSRenderer(IEntityController entity)
        {
            _entity = entity;
            
            
            
        }

            public void FlipTheObject(float direction)
        {
            if(direction == 0f) return ;
            float mathValue = Mathf.Sign(direction);
            
            if(mathValue != _entity.transform.localScale.x)
            {
                _entity.transform.localScale = new Vector2(mathValue,1);
            }
        }
    }

   


}


