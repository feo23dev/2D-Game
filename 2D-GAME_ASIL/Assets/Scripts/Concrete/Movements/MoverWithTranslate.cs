using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Movements;
using UProje.Controllers;

namespace UProje.Movements
{
    public class MoverWithTranslate : IMover
    {
        PlayerController _playerController;
        float moveSpeed = 2f;
        public MoverWithTranslate(PlayerController playerController)
        {
            _playerController = playerController; 
        }
        public void Tick(float Horizontal)
        {
            _playerController.transform.Translate(Vector2.right * Horizontal *Time.deltaTime * moveSpeed);
            
        }
    }


}

