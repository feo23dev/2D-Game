using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Combat;
using UProje.Animations;

namespace UProje.Combats
{
    public class PlayerAttacker : Attacker
    {

        [SerializeField] Transform attackTransform;
        [SerializeField] float attackRadius = 1f;
        Collider2D[] _attackResults;

        private void Awake()
        {
            _attackResults = new Collider2D[10];
        }

        private void OnEnable()
        {
            GetComponent<AnimationImpactWatcher>().OnImpact += ActOnImpact;
        }

        private void OnDisable()
        {
            GetComponent<AnimationImpactWatcher>().OnImpact -= ActOnImpact;
        }

        private void ActOnImpact()
        {
            int hitCount = Physics2D.OverlapCircleNonAlloc(attackTransform.position + attackTransform.forward, attackRadius, _attackResults);

            for (int i = 0; i < hitCount; i++)
            {
                if(_attackResults[i].TryGetComponent<ITakeHit>(out ITakeHit tookHit))
                {
                    ITakeHit takeHit = tookHit;
                    tookHit.TakeHit(this);
                }
               
            }
        }
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackTransform.position + attackTransform.forward,attackRadius);
        }


    }

}


