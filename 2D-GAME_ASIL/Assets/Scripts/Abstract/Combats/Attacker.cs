using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Combat;

namespace UProje.Abstract.Combat
{

    public abstract class Attacker : MonoBehaviour , IAttacker
    {
        [SerializeField] int _damage = 1;

        public int Damage => _damage;

        public virtual void Attack(ITakeHit takeHit)
        {
            takeHit.TakeHit(this);
        }
    }


}

