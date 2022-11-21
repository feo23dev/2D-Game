using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Movements;

namespace UProje.Movements
{
    public class OnGround : MonoBehaviour , IOnGround
    {
        [SerializeField] Transform[] feet;
        [SerializeField] LayerMask _layer;
        bool _onGround;
        public bool onGround => _onGround;

        
        

        private void Start()
        {

        }

        private void Update()
        {
            foreach (Transform foot in feet)
            {
                Raycasting(foot);
                if(_onGround) break;
                
            }

        }

        private void Raycasting(Transform transform)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,.1f,_layer);
            Debug.DrawRay(transform.position,Vector2.down);
            if (hit.collider != null)
            {
                _onGround = true;  
            }
            else
            {
                _onGround = false;
            }
            
            
        }
    }


}


