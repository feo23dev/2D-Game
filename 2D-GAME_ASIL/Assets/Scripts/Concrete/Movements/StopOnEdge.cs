using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Movements;

namespace UProje.Movements
{
    [RequireComponent(typeof(Collider2D))]
    public class StopOnEdge : MonoBehaviour, IStopOnEdge

    {
        Collider2D _collider2D;
        [SerializeField] float distance = 0.1f;
        [SerializeField] LayerMask _layerMask;
        float _direction;
        bool message;
        

        public bool isRightDirection { get; set; }

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _direction = transform.localScale.x;
        }
        // Start is called before the first frame update

        private void Update()
        {
            
            HasReachEdge();
            
        }

        public bool HasReachEdge()
        {
            float x = GetPosition();
            float y = _collider2D.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down,distance ,_layerMask);
            Debug.DrawRay(origin, Vector2.down, Color.red);

            if (hit.collider == null)    
            { 
                return true;
            }
            else
            {
                return false;
            }
            
            
            
        }

        private float GetPosition()
        {
            isRightDirection = _direction == 1;

            if (isRightDirection)
            {
                return _collider2D.bounds.max.x + 0.1f;
            }
            else
            {
                return _collider2D.bounds.min.x - 0.1f;
            }
            

        }
    }


}



