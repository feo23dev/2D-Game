using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Controllers;
using UProje.Abstract.Movements;
using UProje.Controllers;

namespace UProje.Movements
{
    public class MoverWithTranslate : IMover
    {
        IEntityController _entity;
        //float moveSpeed = 2f;
        float _moveSpeed;
        public MoverWithTranslate(IEntityController entity, float moveSpeed)
        {
            _entity =entity;
            _moveSpeed = moveSpeed;
        }
        public void Tick(float Horizontal)
        {
            _entity.transform.Translate(Vector2.right * Horizontal *Time.deltaTime * _moveSpeed);
            
        }
    }


}

